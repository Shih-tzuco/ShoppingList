using System;
using System.Windows.Forms;

namespace ShoppingList
{
    public partial class ShoppingListForm : Form
    {
        private string name;

        public ShoppingListForm()
        {
            InitializeComponent();
        }

        private void Add()
        {
            textBox.Text = textBox.Text.Trim();
            checkedListBox.Items.Add(textBox.Text);
            textBox.Clear();
            textBox.Focus();
            addButton.Enabled = false;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void CheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkedListBox.SelectedItems.Count != 0)
            {
                addButton.Enabled = false;
                deleteButton.Enabled = true;
                upButton.Enabled = true;
                downButton.Enabled = true;
            }
        }

        private void DownButton_Click(object sender, EventArgs e)
        {
            int highestIndex = 0;
            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                if (!checkedListBox.SelectedIndices.Contains(i))
                {
                    highestIndex = i;
                }
            }

            int select = checkedListBox.SelectedItems.Count;
            for (int i = select - 1; i >= 0; i--)
            {
                if (checkedListBox.SelectedIndices[i] < checkedListBox.Items.Count - 1)
                {
                    int index = checkedListBox.SelectedIndices[i] + 2;
                    if (checkedListBox.CheckedItems.Count > 0)
                    {
                        checkedListBox.Items.Insert(index, checkedListBox.SelectedItems[i]);
                        checkedListBox.Items.RemoveAt(index - 2);
                        checkedListBox.SelectedItem = checkedListBox.Items[index - 1];
                        checkedListBox.SetItemChecked(index - 1, true);
                    }
                    else
                    {
                        checkedListBox.Items.Insert(index, checkedListBox.SelectedItems[i]);
                        checkedListBox.Items.RemoveAt(index - 2);
                        checkedListBox.SelectedItem = checkedListBox.Items[index - 1];
                    }
                }
            }
            checkedListBox.EndUpdate();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (checkedListBox.Items.Count > 0)
            {
                checkedListBox.Items.RemoveAt(checkedListBox.SelectedIndex);
            }
            deleteButton.Enabled = false;
            upButton.Enabled = false;
            downButton.Enabled = false;
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < textBox.Text.Length; i++)
            {
                if (textBox.Text[i] != ' ')
                {
                    addButton.Enabled = true;
                }
            }
            name = textBox.Text;
            foreach (string item in checkedListBox.Items)
            {
                name = textBox.Text.Trim();
                if (item.Equals(name))
                {
                    addButton.Enabled = false;
                }
            }
            if (textBox.Text.Length == 0)
            {
                addButton.Enabled = false;
            }
        }

        private void UpButton_Click(object sender, EventArgs e)
        {
            int lowestIndex = checkedListBox.Items.Count - 1;

            for ( int i = lowestIndex; i >= 0; i --)
            {
                if (!checkedListBox.SelectedIndices.Contains(i))
                {
                    lowestIndex = i;
                }
            }
            checkedListBox.BeginUpdate();
            int select = checkedListBox.SelectedItems.Count;

            for (int i = 0; i < select; i++)
            {
                if (checkedListBox.SelectedIndices[i] > 0 )
                {
                    int index = checkedListBox.SelectedIndices[i] - 1;
                    if (checkedListBox.CheckedItems.Count > 0)
                    {
                        checkedListBox.Items.Insert(index, checkedListBox.SelectedItems[i]);
                        checkedListBox.Items.RemoveAt(index + 2);
                        checkedListBox.SelectedItem = checkedListBox.Items[index];
                        checkedListBox.SetItemChecked(index, true);
                    }
                    else
                    {
                        checkedListBox.Items.Insert(index, checkedListBox.SelectedItems[i]);
                        checkedListBox.Items.RemoveAt(index + 2);
                        checkedListBox.SelectedItem = checkedListBox.Items[index];
                    }  
                }
            }
            checkedListBox.EndUpdate();
        }
    }
}