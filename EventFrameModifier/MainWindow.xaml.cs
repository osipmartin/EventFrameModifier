using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OSIsoft.AF;
using OSIsoft.AF.EventFrame;
using OSIsoft.AF.Asset;
using OSIsoft.AF.Search;
using OSIsoft.AF.Time;
using System.Diagnostics;
using System.IO;

namespace EventFrameModifier
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public PISystem server;
		public AFDatabase db;
		public AFElementTemplate eventFrameTemplate;
		public string matchingAttribute;

		public struct CSVLine
		{
			public int ID { get; set; }
			public string Value { get; set; }

			public CSVLine(int id, string value) { ID = id; Value = value; }
		}

		public MainWindow()
		{
			InitializeComponent();
		}

		private void CSVFile_Click(object sender, RoutedEventArgs e)
		{
			// Create OpenFileDialog 
			Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

			// Set filter for file extension and default file extension 
			dlg.DefaultExt = ".csv";
			dlg.Filter = "Text Files (*.csv)|*.csv";

			// Display OpenFileDialog by calling ShowDialog method 
			bool? result = dlg.ShowDialog();

			// Get the selected file name and display in a TextBox 
			if (result == true)
			{
				// Open document 
				string filename = dlg.FileName;
				CSV.Text = filename;
			}
		}

		private void AFServer_Loaded(object sender, RoutedEventArgs e)
		{
			PISystems ps = new PISystems();

			//set the items in the box to display the available servers
			AFServer.ItemsSource = ps;
			AFServer.DisplayMemberPath = "Name";
			AFServer.SelectedItem = ps.DefaultPISystem;
		}

		private void AFServer_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			server = AFServer.SelectedItem as PISystem;

			//set the items in the database box to be the available databases for the selected server
			AFDatabase.ItemsSource = server.Databases;
			AFDatabase.DisplayMemberPath = "Name";
			AFDatabase.SelectedItem = server.Databases.DefaultDatabase;

			db = server.Databases.DefaultDatabase;
		}

		private void AFDatabase_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			db = AFDatabase.SelectedItem as AFDatabase;

			//set the items in the Event Frame Template Box with the available EFT
			List<AFElementTemplate> et = db.ElementTemplates.Where(t => t.InstanceType.Name == "AFEventFrame").OrderBy( t => t.Name ).ToList();
			EFT.ItemsSource = et;
			EFT.DisplayMemberPath = "Name";

			eventFrameTemplate = et.FirstOrDefault();
			AFDatabase.SelectedItem = eventFrameTemplate;
		}

		private void EFT_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			eventFrameTemplate = EFT.SelectedItem as AFElementTemplate;

			//set the items in the matching attributes box with the attributes from this template
			MatchingAttribute.ItemsSource = eventFrameTemplate.AttributeTemplates;
			MatchingAttribute.DisplayMemberPath = "Name";

			MatchingAttribute.SelectedItem = eventFrameTemplate.AttributeTemplates[0];
		}

		private void MatchingAttribute_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			matchingAttribute = MatchingAttribute.Text;
		}

		private void Button_Click(object sender, RoutedEventArgs re)
		{		
			//parse the start and end times
			AFTime startTime, endTime;
			if (AFTime.TryParse(StartDate.Text, out startTime) && AFTime.TryParse(EndDate.Text, out endTime)) {
				//find event frames with the event frame template in the time slot
				var search = new AFEventFrameSearch(db, "Find", AFSearchMode.Overlapped, startTime, endTime, $"Template:={eventFrameTemplate.Name}");
				List<AFEventFrame> efs = search.FindEventFrames().OrderBy( ef => ef.Attributes[matchingAttribute].GetValue().ValueAsInt32() ).ToList();

				//read in csv file
				List<CSVLine> lines = new List<CSVLine>();
				using (var reader = new StreamReader(CSV.Text))
				{
					while (!reader.EndOfStream)
					{
						var line = reader.ReadLine();
						var split = line.Split(',');

						int id;
						if (int.TryParse(split[0], out id)) {
							lines.Add(new CSVLine(id, split[1]));
						}					
					}
				}
				lines = lines.OrderBy(line => line.ID).ToList();

				//iterate through lines of csv 
				//match identifier column with "matchingAttribute"
				int e = 0, l = 0;
				while (e < efs.Count && l < lines.Count)
				{
					int ef_id = efs[e].Attributes[matchingAttribute].GetValue().ValueAsInt32();
					int line_id = lines[l].ID;
					if (ef_id == line_id)
					{
						//match -- update
						efs[e].Attributes["Attribute1"].SetValue(new AFValue(lines[l].Value));
						l++;
						e++;
					}
					else if (ef_id > line_id)
					{
						l++;
					}
					else
					{
						e++;
					}
				}
			}
		}
	}
}
