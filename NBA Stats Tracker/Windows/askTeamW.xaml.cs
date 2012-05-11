#region Copyright Notice

// Created by Lefteris Aslanoglou, (c) 2011-2012
// 
// Implementation of thesis
// "Application Development for Basketball Statistical Analysis in Natural Language"
// under the supervision of Prof. Athanasios Tsakalidis & MSc Alexandros Georgiou
// 
// All rights reserved. Unless specifically stated otherwise, the code in this file should 
// not be reproduced, edited and/or republished without explicit permission from the 
// author.

#endregion

#region Using Directives

using System.Collections.Generic;
using System.Windows;

#endregion

namespace NBA_Stats_Tracker.Windows
{
    /// <summary>
    /// Interaction logic for askTeam.xaml
    /// </summary>
    public partial class askTeamW : Window
    {
        private readonly bool _oneTeam;
        private readonly bool _versus;

        public askTeamW(bool versus, int index = 0)
        {
            InitializeComponent();
            _versus = versus;

            if (!versus)
            {
                cmbTeams1.Items.Add("Mode 0");
                cmbTeams1.Items.Add("Mode 1");
                cmbTeams1.Items.Add("Mode 2");
                cmbTeams1.Items.Add("Mode 3");
                cmbTeams1.Items.Add("Mode 4");
                cmbTeams1.Items.Add("Mode 5");
                cmbTeams1.Items.Add("Mode 6");
                cmbTeams2.Visibility = Visibility.Hidden;
            }
            else
            {
                label1.Content = "Pick the two teams";
                cmbTeams2.Visibility = Visibility.Visible;
                foreach (KeyValuePair<string, int> kvp in MainWindow.TeamOrder)
                {
                    cmbTeams1.Items.Add(kvp.Key);
                    cmbTeams2.Items.Add(kvp.Key);
                }
            }

            cmbTeams1.SelectedIndex = index;
            if (index != 0)
                cmbTeams2.SelectedIndex = 0;
            else
                cmbTeams2.SelectedIndex = 1;
        }

        public askTeamW(List<string> teams)
        {
            InitializeComponent();

            _oneTeam = true;

            label1.Content = "Sign the player to which team?";
            cmbTeams1.ItemsSource = teams;
            cmbTeams2.Visibility = Visibility.Hidden;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (!_oneTeam)
            {
                if (!_versus)
                {
                    Helper.mode = cmbTeams1.SelectedItem.ToString();
                }
                else
                {
                    var vw = new versusW(cmbTeams1.SelectedItem.ToString(), cmbTeams2.SelectedItem.ToString(),
                                         MainWindow.tst);
                    vw.ShowDialog();
                }
            }
            else
            {
                if (cmbTeams1.SelectedIndex == -1) return;
                playerOverviewW.askedTeam = cmbTeams1.SelectedItem.ToString();
            }
            Close();
        }
    }
}