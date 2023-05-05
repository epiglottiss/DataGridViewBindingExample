using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridBindingExample
{
    public partial class Form1 : Form
    {
        private BindingSource bindingSource = new BindingSource();
        private BindingList<SelectedProcess> selectedProcesses = new BindingList<SelectedProcess>();
        public Form1()
        {
            InitializeComponent();
            // bindingSource. = selectedProcesses;
            //bindingSource.Add(new SelectedProcess(1,"hihi","hihi#1"));
            //bindingSource.Add(new SelectedProcess(2, "hihi2", "hihi#2"));
            //bindingSource.Add(new SelectedProcess(3, "hihi2", "hihi#2"));

            selectedProcesses.Add(new SelectedProcess(1, "hihi", "hihi#1"));
            selectedProcesses.Add(new SelectedProcess(2, "hihi2", "hihi#2"));
            selectedProcesses.Add(new SelectedProcess(3, "hihi2", "hihi#2"));

            listBox1.DataSource = selectedProcesses;
            listBox1.MultiColumn = true;
            listBox1.ColumnWidth = 50;

            dataGridView1.DataSource = selectedProcesses;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            selectedProcesses.Add(new SelectedProcess(3, "hihi2", "hihi#2"));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //selectedProcesses.RemoveAt(0);
            selectedProcesses.Remove(selectedProcesses.FirstOrDefault(sp=>sp.Id==1));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            selectedProcesses.ElementAt(0).Id += 3;
        }

        private int currentSortedIndex = -1;
        private bool isOrderedDescending= false;
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            currentSortedIndex = e.ColumnIndex;

            isOrderedDescending = !isOrderedDescending;

            dataGridView1.Sort(dataGridView1.Columns[e.ColumnIndex], 
                isOrderedDescending ? ListSortDirection.Descending : ListSortDirection.Ascending);
        }
    }
}
