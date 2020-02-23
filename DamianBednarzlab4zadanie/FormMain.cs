using DamianBednarzlab4zadanie.Models;
using DamianBednarzlab4zadanie.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DamianBednarzlab4zadanie
{
    public partial class FormMain : Form
    {
        private readonly IGradingGeneric<Student> _students;
        private readonly IGradingGeneric<Teacher> _teachers;
        private readonly IGradingGeneric<Subject> _subjects;
        private readonly IGradingGeneric<Parent> _parents;
        private readonly IGradingGeneric<Grade> _grades;
        /// <summary>
        /// konstruktor, uzupełnia zmienne służące do generowania elementów, i wypełnia dataGridView
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
            _grades = new GradingGeneric<Grade>();
            _parents = new GradingGeneric<Parent>();
            _teachers = new GradingGeneric<Teacher>();
            _subjects = new GradingGeneric<Subject>();
            _students = new GradingGeneric<Student>();
            LoadData();
        }
        /// <summary>
        /// funkcja odświeżająca dane we wszystkich dataGridView
        /// </summary>
        private void LoadData()
        {
            dataGridViewStudent.DataSource = _students.GetAll();
            dataGridViewStudent.Columns[4].Visible = false;
            dataGridViewStudent.Columns[6].Visible = false;
            dataGridViewTeacher.DataSource = _teachers.GetAll();
            dataGridViewGrade.DataSource = _grades.GetAll();
            dataGridViewGrade.Columns[4].Visible = false;
            dataGridViewGrade.Columns[6].Visible = false;
        }
        /// <summary>
        /// dodawanie ucznia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddStudent_Click(object sender, EventArgs e)
        {
            var StudentFirstName = textBoxStudentAddName.Text;
            var StudentLastName = textBoxStudentAddSurname.Text;
            var StudentParentId = textBoxStudentAddParentId.Text;
            var StudentTeacherId = textBoxStudentAddTeacherId.Text;

            Student newStudent = new Student
            {
                FirstName = StudentFirstName,
                LastName = StudentLastName,
                ParentId = Int32.Parse(StudentParentId),
                TeacherId = Int32.Parse(StudentTeacherId)
            };
            _students.Create(newStudent);
            _students.Save();
            LoadData();
        }
        /// <summary>
        /// dodawanie nauczyciela
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddTeacher_Click(object sender, EventArgs e)
        {
            var TeacherFirstName = textBoxAddTeacherName.Text;
            var TeacherLastName = textBoxAddTeacherSurname.Text;
            Teacher newTeacher = new Teacher
            {
                FirstName = TeacherFirstName,
                LastName = TeacherLastName
            };
            _teachers.Create(newTeacher);
            _teachers.Save();
            LoadData();
        }
        /// <summary>
        /// dodawanie oceny
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddGrade_Click(object sender, EventArgs e)
        {
            var GradeName = textBoxAddGradeName.Text;
            var GradeNote = textBoxAddGradeNote.Text;
            var GradeStudentId = textBoxAddGradeStudentId.Text;
            var GradeSubjectId = textBoxAddGradeSubjectId.Text;
            Grade newGrade = new Grade
            {
                Name = GradeName,
                Note = Int32.Parse(GradeNote),
                StudentId = Int32.Parse(GradeStudentId),
                SubjectId = Int32.Parse(GradeSubjectId)
            };
        }
        /// <summary>
        /// usuwanie ucznia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDeleteStudent_Click(object sender, EventArgs e)
        {
            var selectedStudentIndex = Int32.Parse(dataGridViewStudent.SelectedRows[0].Cells[0].Value.ToString());
            var deleteStudent = _students.GetById(selectedStudentIndex);

            _students.DeleteById(deleteStudent.Id);
            _students.Save();
            LoadData();
        }
        /// <summary>
        /// usuwanie nauczyciela
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDeleteTeacher_Click(object sender, EventArgs e)
        {
            var selectedTeacherIndex = Int32.Parse(dataGridViewTeacher.SelectedRows[0].Cells[0].Value.ToString());
            var deleteTeacher = _teachers.GetById(selectedTeacherIndex);

            _teachers.DeleteById(deleteTeacher.Id);
            _teachers.Save();
            LoadData();
        }
        /// <summary>
        /// usuwanie oceny
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDeleteGrade_Click(object sender, EventArgs e)
        {
            var selectedGradeIndex = Int32.Parse(dataGridViewGrade.SelectedRows[0].Cells[0].Value.ToString());
            var deleteGrade = _grades.GetById(selectedGradeIndex);

            _grades.DeleteById(deleteGrade.Id);
            _grades.Save();
            LoadData();
        }
        /// <summary>
        /// funkcja zmieniająca dane
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUpdateTeacher_Click(object sender, EventArgs e)
        {
            int teacherUpdatedId = Int32.Parse(textBoxUpdateTeacherId.Text);
            var teacherUpdatedFirstName = textBoxUpdateTeacherName.Text;
            var teacherUpdatedLastName = textBoxUpdateTeacherSurname.Text;

            Teacher editTeacher = _teachers.GetById(teacherUpdatedId);
            editTeacher.FirstName = teacherUpdatedFirstName;
            editTeacher.LastName = teacherUpdatedLastName;

            _teachers.Update(editTeacher);
            _teachers.Save();

            LoadData();
        }
        /// <summary>
        /// funkcja zmieniająca dane oceny
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUpdateGrade_Click(object sender, EventArgs e)
        {
            int gradeUpdatedId = Int32.Parse(textBoxUpdateGradeId.Text);
            var gradeUpdatedName = textBoxUpdateGradeName.Text;
            var gradeUpdatedNote = textBoxUpdateGradeNote.Text;
            var gradeUpdatedStudentId = textBoxUpdateGradeStudentId.Text;
            var gradeUpdatedSubjectId = textBoxUpdateGradeSubjectId.Text;

            Grade editGrade =  _grades.GetById(gradeUpdatedId);
            editGrade.Name = gradeUpdatedName;
            editGrade.Note = Int32.Parse(gradeUpdatedNote);
            editGrade.StudentId = Int32.Parse(gradeUpdatedStudentId);
            editGrade.SubjectId = Int32.Parse(gradeUpdatedSubjectId);

            _grades.Update(editGrade);
            _grades.Save();

            LoadData();
        }
        /// <summary>
        /// Funkcja zmieniająca dane nauczyciela
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUpdateStudent_Click(object sender, EventArgs e)
        {
            int studentUpdatedId = Int32.Parse(textBoxUpdateStudentId.Text);
            var studentUpdatedFirstName = textBoxUpdateStudentName.Text;
            var studentUpdatedLastName = textBoxUpdateStudentSurname.Text;
            var studentUpdatedParentId = textBoxUpdateStudentParentId.Text;
            var studentUpdatedTeacherId = textBoxStudentAddTeacherId.Text;

            Student editStudent = _students.GetById(studentUpdatedId);
            editStudent.FirstName = studentUpdatedFirstName;
            editStudent.LastName = studentUpdatedLastName;
            editStudent.ParentId = Int32.Parse(studentUpdatedParentId);
            editStudent.TeacherId = Int32.Parse(studentUpdatedTeacherId);

            _students.Update(editStudent);
            _students.Save();

            LoadData();
        }
    }
}
