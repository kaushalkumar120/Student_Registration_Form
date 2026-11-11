using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Project2_StudentRegistrationForm;

public class Form1 : Form
{
    TextBox txtName = new();
    TextBox txtEmail = new();
    RadioButton rbMale = new();
    RadioButton rbFemale = new();
    ComboBox cmbCourse = new();
    CheckBox chkReading = new();
    CheckBox chkSports = new();
    CheckBox chkMusic = new();
    DateTimePicker dtpDOB = new();
    Button btnSubmit = new();
    Label lblSummary = new();

    public Form1()
    {
        Text = "Student Registration Form";
        Size = new Size(700, 650);
        StartPosition = FormStartPosition.CenterScreen;

        AddLabel("Name:", 30, 30);
        txtName.SetBounds(150, 25, 300, 30);
        Controls.Add(txtName);

        AddLabel("Email:", 30, 80);
        txtEmail.SetBounds(150, 75, 300, 30);
        Controls.Add(txtEmail);

        AddLabel("Gender:", 30, 130);
        rbMale.Text = "Male"; rbMale.SetBounds(150, 125, 80, 30);
        rbFemale.Text = "Female"; rbFemale.SetBounds(240, 125, 100, 30);
        Controls.AddRange(new Control[] { rbMale, rbFemale });

        AddLabel("Course:", 30, 180);
        cmbCourse.SetBounds(150, 175, 200, 30);
        cmbCourse.Items.AddRange(new object[] { "BCA", "B.Tech", "MCA", "B.Sc", "M.Tech" });
        Controls.Add(cmbCourse);

        AddLabel("Hobbies:", 30, 230);
        chkReading.Text = "Reading"; chkReading.SetBounds(150, 225, 100, 30);
        chkSports.Text = "Sports"; chkSports.SetBounds(250, 225, 90, 30);
        chkMusic.Text = "Music"; chkMusic.SetBounds(340, 225, 90, 30);
        Controls.AddRange(new Control[] { chkReading, chkSports, chkMusic });

        AddLabel("DOB:", 30, 280);
        dtpDOB.SetBounds(150, 275, 200, 30);
        dtpDOB.Format = DateTimePickerFormat.Short;
        Controls.Add(dtpDOB);

        btnSubmit.Text = "Submit";
        btnSubmit.SetBounds(150, 330, 120, 35);
        btnSubmit.Click += BtnSubmit_Click;
        Controls.Add(btnSubmit);

        lblSummary.BorderStyle = BorderStyle.FixedSingle;
        lblSummary.AutoSize = false;
        lblSummary.SetBounds(30, 390, 610, 170);
        Controls.Add(lblSummary);
    }

    void AddLabel(string text, int x, int y)
    {
        Label label = new() { Text = text, AutoSize = true };
        label.SetBounds(x, y + 5, 100, 25);
        Controls.Add(label);
    }

    void BtnSubmit_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtName.Text))
        {
            MessageBox.Show("Enter name."); return;
        }

        if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
        {
            MessageBox.Show("Enter a valid email."); return;
        }

        if (!rbMale.Checked && !rbFemale.Checked)
        {
            MessageBox.Show("Select gender."); return;
        }

        if (cmbCourse.SelectedIndex == -1)
        {
            MessageBox.Show("Select course."); return;
        }

        if (!chkReading.Checked && !chkSports.Checked && !chkMusic.Checked)
        {
            MessageBox.Show("Select at least one hobby."); return;
        }

        string gender = rbMale.Checked ? "Male" : "Female";
        string hobbies = string.Join(", ",
            new[] {
                chkReading.Checked ? "Reading" : "",
                chkSports.Checked ? "Sports" : "",
                chkMusic.Checked ? "Music" : ""
            }.Where(x => x != ""));

        lblSummary.Text =
            $"Name: {txtName.Text.Trim()}\n" +
            $"Email: {txtEmail.Text.Trim()}\n" +
            $"Gender: {gender}\n" +
            $"Course: {cmbCourse.Text}\n" +
            $"Hobbies: {hobbies}\n" +
            $"DOB: {dtpDOB.Value:dd/MM/yyyy}";
    }
}
