using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
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
using OpenDis.Core;
using Cet2006 = OpenDis.Enumerations.Cet2006;
using Cet2010 = OpenDis.Enumerations.Cet2010;

namespace OpenDis.Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Cet2006.Cet cet2006EntityTypes = Cet2006.CetFactory.CreateEntityTypes();
        private static Cet2006.Cet cet2006AggregateTypes = Cet2006.CetFactory.CreateAggregateTypes();
        private static Cet2010.Cet cet2010EntityTypes = Cet2010.CetFactory.CreateEntityTypes();
        private static Cet2010.Cet cet2010AggregateTypes = Cet2010.CetFactory.CreateAggregateTypes();

        private static List<ICetItem> cet2006EntityTypesList;
        private static List<ICetItem> cet2010EntityTypesList;

        private static IEnumerable enumerations;

        private static ListCollectionView cet2006View;
        private static ListCollectionView cet2010View;

        public static string GetDescription<T>(T value)
        {
            return "";
        }

        static MainWindow()
        {
            GetDescription<Orientation>(Orientation.Vertical);

            cet2006EntityTypes = Cet2006.CetFactory.CreateEntityTypes();
            cet2006AggregateTypes = Cet2006.CetFactory.CreateAggregateTypes();
            cet2010EntityTypes = Cet2010.CetFactory.CreateEntityTypes();
            cet2010AggregateTypes = Cet2010.CetFactory.CreateAggregateTypes();

            cet2006EntityTypesList = Cet2006.CetFactory.Transform(cet2006EntityTypes);
            cet2010EntityTypesList = Cet2010.CetFactory.Transform(cet2010EntityTypes);

            cet2006View = new ListCollectionView(cet2006EntityTypesList);
            cet2006View.GroupDescriptions.Add(new PropertyGroupDescription("Country"));

            cet2010View = new ListCollectionView(cet2010EntityTypesList);
            cet2010View.GroupDescriptions.Add(new PropertyGroupDescription("Country"));
            
            IEnumerable<Type> types = from a in 
                                          Assembly.GetAssembly(typeof(IPdu)).GetTypes() 
                                      where a.IsEnum && a.Namespace.Contains("Enumerations") 
                                      select a;
            enumerations =
                from n in
                    (from m in types select m.Namespace).Distinct<string>()
                select new
                {
                    Namespace = n,
                    Enums = from t in types
                            select new
                            {
                                Name = t.Name,
                                Values = from r in Enum.GetNames(t) select new { Name = r, Value = Convert.ChangeType(Enum.Parse(t, r), Enum.GetUnderlyingType(t)) }
                            }
                };
        }

        public MainWindow()
        {
            InitializeComponent();

            treeViewEntityTypes.DataContext = cet2006EntityTypes.Entities;
            dataGridEntityTypes.DataContext = cet2006View;
            treeViewAggregateTypes.DataContext =  cet2006AggregateTypes.Entities;
            this.treeViewEnumerations.DataContext = enumerations;
        }

        private void toggleEntityGrid_Click(object sender, RoutedEventArgs e)
        {
            this.toggleEntityTree.IsChecked = false;
            this.toggleEntityGrid.IsChecked = true;
            this.treeViewEntityTypes.Visibility = Visibility.Hidden;
            this.dataGridEntityTypes.Visibility = Visibility.Visible;
        }

        private void toggleEntityTree_Click(object sender, RoutedEventArgs e)
        {
            this.toggleEntityTree.IsChecked = true;
            this.toggleEntityGrid.IsChecked = false;
            this.treeViewEntityTypes.Visibility = Visibility.Visible;
            this.dataGridEntityTypes.Visibility = Visibility.Hidden;
        }

        private void toggleCet2010_Click(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            treeViewEntityTypes.DataContext = cet2010EntityTypes.Entities;
            dataGridEntityTypes.DataContext = cet2010View;
            this.toggleCet2010.IsChecked = true;
            this.toggleCet2006.IsChecked = false;
            Cursor = Cursors.Arrow;
        }

        private void toggleCet2006_Click(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            treeViewEntityTypes.DataContext = cet2006EntityTypes.Entities;
            dataGridEntityTypes.DataContext = cet2006View;
            this.toggleCet2010.IsChecked = false;
            this.toggleCet2006.IsChecked = true;
            Cursor = Cursors.Arrow; 
        }

        private void toggleAggregate2010_Click(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            treeViewAggregateTypes.DataContext = cet2010AggregateTypes.Entities;
            this.toggleAggregate2010.IsChecked = true;
            this.toggleAggregate2006.IsChecked = false;
            Cursor = Cursors.Arrow;
        }

        private void toggleAggregate2006_Click(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            treeViewAggregateTypes.DataContext = cet2006AggregateTypes.Entities;
            this.toggleAggregate2010.IsChecked = false;
            this.toggleAggregate2006.IsChecked = true;
            Cursor = Cursors.Arrow;
        }
    }
}
