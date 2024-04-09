using BookstoreDBLib;
using BookstoreDBLib.Entities;
using BookStoreDBLib;
using FinalWindowApp.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinalWindowApp
{
    public partial class MainWindow : Window
    {
        BookstoreDB context;
        string loadedTable;
        List<Book> gridBooks { get; set; }
        DbSet<Author> gridAuthor { get; set; }
        DbSet<PublishingHouse> gridPublishingHouses { get; set; }
        DbSet<Genre> gridGenres { get; set; }
        DbSet<Series> gridSeries { get; set; }
        DbSet<SpecialOffer> gridSpecialOffers { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            context = new BookstoreDB();

            if (!Login())
            {
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();
            }

            if (!FileUserManager.isFileExists())
            {
                Close();
            }

            if (!Login())
            {
                Close();
            }
        }

        private bool Login()
        {
            bool res = false;
            User user = new User();

            if (FileUserManager.isFileExists())
            {
                FileUserManager.ReadUser(user);
                res = LoginManager.LogIn(context, user);
            }
            else
            {
                res = false;
            }

            return res;
        }

        private void LoadFullDBBtn_Click(object sender, RoutedEventArgs e)
        {
            LoadFullInfoTable();
            ConfigureMenu();
        }

        private void LoadFullInfoTable(Func<Book, int> orderBy = null)
        {
            List<string> unneededColumnsHeaders = new List<string>() { "AuthorId", "PublishingHouseId", "GenreId", "SeriesId", "SpecialOfferId" };
            List<string> neededColumns = new List<string>() { "Author", "PublishingHouse", "Genre", "Series", "SpecialOffer" };
            loadedTable = "FullInfo";

            LoadFullInfoTableData(orderBy);
            List<int> unneededColumnsIndexes = GetColumnsIndexesByColumnsHeaders(unneededColumnsHeaders);
            ReplaceColumnsByIndex(unneededColumnsIndexes, neededColumns);
            DeleteColumns(unneededColumnsHeaders);
        }

        private void LoadFullInfoTableData(Func<Book, int> orderBy = null)
        {
            if (orderBy != null)
            {
                dataGrid.ItemsSource = context.Books.OrderByDescending(orderBy).ToList();
            }
            else
            {
                dataGrid.ItemsSource = context.Books.ToList();
            }
        }

        private List<int> GetColumnsIndexesByColumnsHeaders(List<string> columnsHeaders)
        {
            List<int> indexes = new List<int>();

            foreach (var column in dataGrid.Columns)
            {
                if (columnsHeaders.Contains(column.Header.ToString()))
                {
                    indexes.Add(dataGrid.Columns.IndexOf(column));
                }
            }

            return indexes;
        }

        private void ReplaceColumnsByIndex(List<int> indexes, List<string> columnsStrings)
        {
            List<DataGridColumn> columns = new List<DataGridColumn>();
            int colStringsIndex = 0;

            for (int i = 0; i < dataGrid.Columns.Count(); i++)
            {
                if (!indexes.Contains(i) && !columns.Contains(dataGrid.Columns[i]))
                {
                    columns.Add(dataGrid.Columns[i]);
                }
                else if (indexes.Contains(i))
                {
                    columns.Add(GetColumnByIndexAndHeader(colStringsIndex, columnsStrings));
                    colStringsIndex++;
                }
            }

            foreach (DataGridColumn column in columns)
            {
                dataGrid.Columns.Remove(column);
            }

            foreach (DataGridColumn column in columns)
            {
                dataGrid.Columns.Add(column);
            }
        }

        private DataGridColumn GetColumnByIndexAndHeader(int index, List<string> headers)
        {
            return dataGrid.Columns[GetColumnIndex(index, headers)];
        }

        private int GetColumnIndex(int index, List<string> headers)
        {
            return dataGrid.Columns.IndexOf(GetColumnByHeader(headers[index]));
        }

        private DataGridColumn GetColumnByHeader(string header)
        {
            foreach (var column in dataGrid.Columns)
            {
                if (column.Header.ToString() == header)
                {
                    return column;
                }
            }

            throw new Exception("Column not found");
        }

        private void DeleteColumns(List<string> unneededColumnsHeaders)
        {
            List<DataGridColumn> unneededColumns = new List<DataGridColumn>();

            foreach (var column in dataGrid.Columns)
            {
                if (unneededColumnsHeaders.Contains(column.Header.ToString()))
                {
                    unneededColumns.Add(column);
                }
            }

            foreach (var column in unneededColumns)
            {
                dataGrid.Columns.Remove(column);
            }
        }

        private void ConfigureMenu()
        {
            switch (loadedTable)
            {
                case "FullInfo":
                    ShowOrderingToolBarIfCollapsedOrHidden();
                    ShowMessageToolBarIfCollapsedOrHidden();
                    SetMessageToolBarText("Before loading this table, it is recommended to load: Authors, PublishingHouses, Genres and SpecialOffers tables.");
                    DisableUpdateBtn();
                    break;
                case "Books":
                    ShowOrderingToolBarIfCollapsedOrHidden();
                    HideMessageToolBarIfVisible();
                    EnableUpdateBtnIfDisabled();
                    break;
                case "Authors":
                case "Genres":
                    ShowOrderingToolBarIfCollapsedOrHidden();
                    ShowMessageToolBarIfCollapsedOrHidden();
                    SetMessageToolBarText("Before loading this table, it is recomended to load: FullInfo or Books table.");
                    EnableUpdateBtnIfDisabled();
                    break;
                case "PublishingHouses":
                case "Series":
                case "SpecialOffers":
                    HideOrderingToolBarIfVisible();
                    HideMessageToolBarIfVisible();
                    EnableUpdateBtnIfDisabled();
                    break;

            }
        }

        private void ShowOrderingToolBarIfCollapsedOrHidden()
        {
            if (OrderingToolBar.Visibility == Visibility.Collapsed)
            {
                OrderingToolBar.Visibility = Visibility.Visible;
            }
        }

        private void ShowMessageToolBarIfCollapsedOrHidden()
        {
            if (MessageToolBar.Visibility == Visibility.Collapsed)
            {
                MessageToolBar.Visibility = Visibility.Visible;
            }
        }

        private void SetMessageToolBarText(string text)
        {
            MessageTextBlock.Text = text;
        }

        private void HideOrderingToolBarIfVisible()
        {
            if (OrderingToolBar.Visibility == Visibility.Visible)
            {
                OrderingToolBar.Visibility = Visibility.Collapsed;
            }
        }

        private void HideMessageToolBarIfVisible()
        {
            if (MessageToolBar.Visibility == Visibility.Visible)
            {
                MessageToolBar.Visibility = Visibility.Collapsed;
            }
        }

        private void DisableUpdateBtn()
        {
            UpdateBtn.IsEnabled = false;
            UpdateBtn.Background = new SolidColorBrush(Color.FromRgb(149, 199, 219));
            UpdateBtn.BorderBrush = new SolidColorBrush(Color.FromRgb(182, 212, 222));
        }

        private void EnableUpdateBtnIfDisabled()
        {
            if (!UpdateBtn.IsEnabled)
            {
                UpdateBtn.IsEnabled = true;
                UpdateBtn.Background = Brushes.SkyBlue;
                UpdateBtn.BorderBrush = Brushes.LightBlue;
            }
        }

        private void LoadBooksBtn_Click(object sender, RoutedEventArgs e)
        {
            LoadBooksTable();
            ConfigureMenu();
        }

        private void LoadBooksTable(Func<Book, int> orderBy = null)
        {
            List<string> unneededColumnsHeaders = new List<string>() { "Author", "PublishingHouse", "Genre", "Series", "SpecialOffer" };

            LoadBooksTableData(orderBy);
            DeleteColumns(unneededColumnsHeaders);
        }

        private void LoadBooksTableData(Func<Book, int> orderBy = null)
        {
            loadedTable = "Books";

            if (orderBy != null)
            {
                dataGrid.ItemsSource = context.Books.OrderByDescending(orderBy).ToList();
            }
            else
            {
                dataGrid.ItemsSource = context.Books.ToList();
            }
        }

        private void LoadAuthorsBtn_Click(object sender, RoutedEventArgs e)
        {
            LoadAuthorsTable();
            ConfigureMenu();
        }

        private void LoadAuthorsTable(Func<Author, int> orderBy = null)
        {
            LoadAuthorsTableData(orderBy);
            DeleteColumns(new List<string>() { "Books" });
        }

        private void LoadAuthorsTableData(Func<Author, int> orderBy = null)
        {
            loadedTable = "Authors";
            if (orderBy != null)
            {
                dataGrid.ItemsSource = context.Authors.OrderByDescending(orderBy).ToList();
            }
            else
            {
                dataGrid.ItemsSource = context.Authors.ToList();
            }
        }

        private void LoadPublishingHousesBtn_Click(object sender, RoutedEventArgs e)
        {
            LoadPublishingHousesTable();
            ConfigureMenu();
        }

        private void LoadPublishingHousesTable()
        {
            LoadPublishingHousesTableData();
            DeleteColumns(new List<string>() { "Books" });
        }

        private void LoadPublishingHousesTableData()
        {
            loadedTable = "PublishingHouses";
            dataGrid.ItemsSource = context.PublishingHouses.ToList();
        }

        private void LoadGenresBtn_Click(object sender, RoutedEventArgs e)
        {
            LoadGenresTable();
            ConfigureMenu();
        }

        private void LoadGenresTable(Func<Genre, int> orderBy = null)
        {
            LoadGenresTableData(orderBy);
            DeleteColumns(new List<string>() { "Books" });
        }

        private void LoadGenresTableData(Func<Genre, int> orderBy = null)
        {
            loadedTable = "Genres";
            
            if (orderBy != null)
            {
                dataGrid.ItemsSource = context.Genres.OrderByDescending(orderBy).ToList();
            }
            else
            {
                dataGrid.ItemsSource = context.Genres.ToList();
            }
        }

        private void LoadSeriesBtn_Click(object sender, RoutedEventArgs e)
        {
            LoadSeriesTable();
            ConfigureMenu();
        }

        private void LoadSeriesTable()
        {
            LoadSeriesTableData();
            DeleteColumns(new List<string>() { "Books" });
        }

        private void LoadSeriesTableData()
        {
            loadedTable = "Series";
            dataGrid.ItemsSource = context.Series.ToList();
        }

        private void LoadSpecialOffersBtn_Click(object sender, RoutedEventArgs e)
        {
            LoadSpecialOffersTable();
            ConfigureMenu();
        }

        private void LoadSpecialOffersTable()
        {
            LoadSpecialOffersTableData();
            DeleteColumns(new List<string>() { "Books" });
        }

        private void LoadSpecialOffersTableData()
        {
            loadedTable = "SpecialOffers";
            dataGrid.ItemsSource = context.SpecialOffers.ToList();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Update();
            } catch (Exception ex)
            {
                MessageBox.Show(
                    $"{ex.Message}\n\n{ex.InnerException}", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Update()
        {
            Save();

            switch (loadedTable)
            {
                case "Books":
                    if (IsOldBooksCountSmallerThanUpdated())
                    {
                        AddNewBooks();
                    }

                    if (IsOldBooksCountGreaterThanUpdated())
                    {
                        RemoveBooks();
                    }

                    break;
                case "Authors":
                    if (IsOldAuthorsCountSmallerThanUpdated())
                    {
                        AddNewAuthors();
                    }

                    if (IsOldAuthorsCountGreaterThanUpdated())
                    {
                        RemoveAuthors();
                    }

                    break;
                case "PublishingHouses":
                    if (IsOldPublishingHousesCountSmallerThanUpdated())
                    {
                        AddNewPublishingHouses();
                    }

                    if (IsOldPublishingHousesCountGreaterThanUpdated())
                    {
                        RemovePublishingHouses();
                    }

                    break;
                case "Genres":
                    if (IsOldGenresCountSmallerThanUpdated())
                    {
                        AddNewGenres();
                    }

                    if (IsOldGenresCountGreaterThanUpdated())
                    {
                        RemoveGenres();
                    }

                    break;
                case "Series":
                    if (IsOldSeriesCountSmallerThanUpdated())
                    {
                        AddNewSeries();
                    }

                    if (IsOldSeriesCountGreaterThanUpdated())
                    {
                        RemoveSeries();
                    }

                    break;
                case "SpecialOffers":
                    if (IsOldSpecialOffersCountSmallerThanUpdated())
                    {
                        AddNewSpecialOffers();
                    }

                    if (IsOldSpecialOffersCountGreaterThanUpdated())
                    {
                        RemoveSpecialOffers();
                    }

                    break;
            }

            Save();
        }

        private void Save()
        {
            context.SaveChanges();
        }

        private bool IsOldBooksCountSmallerThanUpdated()
        {
            return context.Books.Count() < dataGrid.Items.Count - 1;
        }

        private void AddNewBooks()
        {
            int oldBooksCount = context.Books.Count();
            int newBooksCount = dataGrid.Items.Count - 1;

            for (int i = oldBooksCount; i < newBooksCount; i++)
            {
                context.Books.Add((Book)dataGrid.Items[i]);
            }
        }

        private bool IsOldBooksCountGreaterThanUpdated()
        {
            return context.Books.Count() > dataGrid.Items.Count - 1;
        }

        private void RemoveBooks()
        {
            context.Books.RemoveRange(GetRemovedBooks());
            
        }

        private List<Book> GetRemovedBooks()
        {
            List<Book> removedBooks = new List<Book>();
            foreach (Book book in context.Books)
            {
                if (!IsUpdatedBooksTableContainsBook(book))
                {
                    removedBooks.Add(book);
                }
            }

            return removedBooks;
        }

        private bool IsUpdatedBooksTableContainsBook(Book book)
        {
            return dataGrid.Items.Contains(book);
        }

        private bool IsOldAuthorsCountSmallerThanUpdated()
        {
            return context.Authors.Count() < dataGrid.Items.Count - 1;
        }

        private void AddNewAuthors()
        {
            int oldAuthorsCount = context.Authors.Count();
            int newAuthorsCount = dataGrid.Items.Count - 1;

            for (int i = oldAuthorsCount; i < newAuthorsCount; i++)
            {
                context.Authors.Add((Author)dataGrid.Items[i]);
            }
        }

        private bool IsOldAuthorsCountGreaterThanUpdated()
        {
            return context.Authors.Count() > dataGrid.Items.Count - 1;
        }

        private void RemoveAuthors()
        {
            context.RemoveRange(GetRemovedAuthors());
        }

        private List<Author> GetRemovedAuthors()
        {
            List<Author> removedAuthors = new List<Author>();

            foreach (Author author in context.Authors)
            {
                if (!IsUpdatedAuthorsTableContainsAuthor(author))
                {
                    removedAuthors.Add(author);
                }
            }

            return removedAuthors;
        }

        private bool IsUpdatedAuthorsTableContainsAuthor(Author author)
        {
            return dataGrid.Items.Contains(author);
        }

        private bool IsOldPublishingHousesCountSmallerThanUpdated()
        {
            return context.PublishingHouses.Count() < dataGrid.Items.Count - 1;
        }

        private void AddNewPublishingHouses()
        {
            int oldPublishingHousesCount = context.PublishingHouses.Count();
            int newPublishingHousesCount = dataGrid.Items.Count - 1;

            for (int i = oldPublishingHousesCount; i < newPublishingHousesCount; i++)
            {
                context.PublishingHouses.Add((PublishingHouse)dataGrid.Items[i]);
            }
        }

        private bool IsOldPublishingHousesCountGreaterThanUpdated()
        {
            return context.PublishingHouses.Count() > dataGrid.Items.Count - 1;
        }

        private void RemovePublishingHouses()
        {
            context.RemoveRange(GetRemovedPublishingHouses());
        }

        private List<PublishingHouse> GetRemovedPublishingHouses()
        {
            List<PublishingHouse> removedPublishingHouses = new List<PublishingHouse>();

            foreach (PublishingHouse publishingHouse in context.PublishingHouses)
            {
                if (!IsUpdatedPublishingHousesTableContainsPublishingHouse(publishingHouse))
                {
                    removedPublishingHouses.Add(publishingHouse);
                }
            }

            return removedPublishingHouses;
        }

        private bool IsUpdatedPublishingHousesTableContainsPublishingHouse(PublishingHouse publishingHouse)
        {
            return dataGrid.Items.Contains(publishingHouse);
        }

        private bool IsOldGenresCountSmallerThanUpdated()
        {
            return context.Genres.Count() < dataGrid.Items.Count - 1;
        }

        private void AddNewGenres()
        {
            int oldGenresCount = context.Genres.Count();
            int newGenresCount = dataGrid.Items.Count - 1;

            for (int i = oldGenresCount; i < newGenresCount; i++)
            {
                context.Genres.Add((Genre)dataGrid.Items[i]);
            }
        }

        private bool IsOldGenresCountGreaterThanUpdated()
        {
            return context.Genres.Count() > dataGrid.Items.Count - 1;
        }

        private void RemoveGenres()
        {
            context.RemoveRange(GetRemovedGenres());
        }

        private List<Genre> GetRemovedGenres()
        {
            List<Genre> removedGenres = new List<Genre>();

            foreach (Genre genre in context.Genres)
            {
                if (!IsUpdatedGenresTableContainsGenre(genre))
                {
                    removedGenres.Add(genre);
                }
            }

            return removedGenres;
        }

        private bool IsUpdatedGenresTableContainsGenre(Genre genre)
        {
            return dataGrid.Items.Contains(genre);
        }

        private bool IsOldSeriesCountSmallerThanUpdated()
        {
            return context.Series.Count() < dataGrid.Items.Count - 1;
        }

        private void AddNewSeries()
        {
            int oldSeriesCount = context.Series.Count();
            int newSeriesCount = dataGrid.Items.Count - 1;

            for (int i = oldSeriesCount; i < newSeriesCount; i++)
            {
                context.Series.Add((Series)dataGrid.Items[i]);
            }
        }

        private bool IsOldSeriesCountGreaterThanUpdated()
        {
            return context.Series.Count() > dataGrid.Items.Count - 1;
        }

        private void RemoveSeries()
        {
            context.RemoveRange(GetRemovedSeries());
        }

        private List<Series> GetRemovedSeries()
        {
            List<Series> removedSeries = new List<Series>();

            foreach (Series series in context.Series)
            {
                if (!IsUpdatedSeriesTableContainsSeries(series))
                {
                    removedSeries.Add(series);
                }
            }

            return removedSeries;
        }

        private bool IsUpdatedSeriesTableContainsSeries(Series series)
        {
            return dataGrid.Items.Contains(series);
        }

        private bool IsOldSpecialOffersCountSmallerThanUpdated()
        {
            return context.SpecialOffers.Count() < dataGrid.Items.Count - 1;
        }

        private void AddNewSpecialOffers()
        {
            int oldSpecialOffersCount = context.SpecialOffers.Count();
            int newSpecialOffersCount = dataGrid.Items.Count - 1;

            for (int i = oldSpecialOffersCount; i < newSpecialOffersCount; i++)
            {
                context.SpecialOffers.Add((SpecialOffer)dataGrid.Items[i]);
            }
        }

        private bool IsOldSpecialOffersCountGreaterThanUpdated()
        {
            return context.SpecialOffers.Count() > dataGrid.Items.Count - 1;
        }

        private void RemoveSpecialOffers()
        {
            context.RemoveRange(GetRemovedSpecialOffers());
        }

        private List<SpecialOffer> GetRemovedSpecialOffers()
        {
            List<SpecialOffer> removedSpecialOffers = new List<SpecialOffer>();

            foreach (SpecialOffer specialOffer in context.SpecialOffers)
            {
                if (!IsUpdatedSpecialOffersTableContainsSpecialOffer(specialOffer))
                {
                    removedSpecialOffers.Add(specialOffer);
                }
            }

            return removedSpecialOffers;
        }

        private bool IsUpdatedSpecialOffersTableContainsSpecialOffer(SpecialOffer specialOffer)
        {
            return dataGrid.Items.Contains(specialOffer);
        }

        private void SelectBtn_Click(object sender, RoutedEventArgs e)
        {
            switch (OrderByComboBox.Text)
            {
                case "None":
                    Select();
                    break;
                case "Day":
                    SelectByViewsPerDay();
                    break;
                case "Week":
                    SelectByViewsPerWeek();
                    break;
                case "Month":
                    SelectByViewsPerMonth();
                    break;
                case "Year":
                    SelectByViewsPerYear();
                    break;
            }
        }

        public void Select()
        {
            switch (loadedTable)
            {
                case "FullInfo":
                    LoadFullInfoTable();
                    break;
                case "Books":
                    LoadBooksTable();
                    break;
                case "Authors":
                    LoadAuthorsTable();
                    break;
                case "Genres":
                    LoadGenresTable();
                    break;
            }
        }

        public void SelectByViewsPerDay()
        {
            switch (loadedTable)
            {
                case "FullInfo":
                    LoadFullInfoTable(b => (int)b.ViewsPerDay);
                    break;
                case "Books":
                    LoadBooksTable(b => (int)b.ViewsPerDay);
                    break;
                case "Authors":
                    LoadAuthorsTable(a => a.Books.Sum(b=> b.ViewsPerDay).Value);
                    break;
                case "Genres":
                    LoadGenresTable(g => g.Books.Sum(b => b.ViewsPerDay).Value);
                    break;
            }
        }

        public void SelectByViewsPerWeek()
        {
            switch (loadedTable)
            {
                case "FullInfo":
                    LoadFullInfoTable(b => (int)b.ViewsPerWeek);
                    break;
                case "Books":
                    LoadBooksTable(b => (int)b.ViewsPerWeek);
                    break;
                case "Authors":
                    LoadAuthorsTable(a => a.Books.Sum(b => b.ViewsPerWeek).Value);
                    break;
                case "Genres":
                    LoadGenresTable(g => g.Books.Sum(b => b.ViewsPerWeek).Value);
                    break;
            }
        }

        public void SelectByViewsPerMonth()
        {
            switch (loadedTable)
            {
                case "FullInfo":
                    LoadFullInfoTable(b => (int)b.ViewsPerMonth);
                    break;
                case "Books":
                    LoadBooksTable(b => (int)b.ViewsPerMonth);
                    break;
                case "Authors":
                    LoadAuthorsTable(a => a.Books.Sum(b => b.ViewsPerMonth).Value);
                    break;
                case "Genres":
                    LoadGenresTable(g => g.Books.Sum(b => b.ViewsPerMonth).Value);
                    break;
            }
        }

        public void SelectByViewsPerYear()
        {
            switch (loadedTable)
            {
                case "FullInfo":
                    LoadFullInfoTable(b => (int)b.ViewsPerYear);
                    break;
                case "Books":
                    LoadBooksTable(b => (int)b.ViewsPerYear);
                    break;
                case "Authors":
                    LoadAuthorsTable(a => a.Books.Sum(b => b.ViewsPerYear).Value);
                    break;
                case "Genres":
                    LoadGenresTable(g => g.Books.Sum(b => b.ViewsPerYear).Value);
                    break;
            }
        }
    }
}