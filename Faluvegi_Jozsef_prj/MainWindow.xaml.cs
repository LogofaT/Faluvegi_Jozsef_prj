using System.Linq;
using System.Windows;


namespace Faluevgi_Jozsef_prj
{
    public partial class MainWindow : Window
    {
        readonly AcademicDbContext context;
        Student NewStudent = new Student();
        Grade NewGrade = new Grade();
        University NewUniversity = new University();
        Student selectedStudent = new Student();
        Grade selectedGrade = new Grade();
        University selectedUniversity = new University();
        public MainWindow(AcademicDbContext context)
        {
            this.context = context;
            InitializeComponent();
            GetStudents();
            GetGrades();
            GetUniversities();
            AddNewStudentGrid.DataContext = NewStudent;
            AddNewGradeGrid.DataContext = NewGrade;
            AddNewUniversityGrid.DataContext = NewUniversity;
            UpdateStudentGrid.IsEnabled = false;
            UpdateGradeGrid.IsEnabled = false;
            UpdateUniversityGrid.IsEnabled = false;
        }
        private void GetStudents()
        {
            StudentDG.ItemsSource = context.Students.ToList();
            StudentCombo.ItemsSource = context.Students.ToList();
            StudentCombo2.ItemsSource = context.Students.ToList();
        }
        private void GetGrades()
        {
            GradesDG.ItemsSource = context.Grades.ToList();
        }
        private void GetUniversities()
        {
            UniversitiesDG.ItemsSource = context.Universities.ToList();
            UniversityCombo.ItemsSource = context.Universities.ToList();
            UniversityCombo2.ItemsSource = context.Universities.ToList();
        }
        private void AddStudent(object s, RoutedEventArgs e)
        {
            if (NewStudent.IsValid) {
                context.Students.Add(NewStudent);
                context.SaveChanges();
                GetStudents();
                NewStudent = new Student();
                AddNewStudentGrid.DataContext = NewStudent;
                MessageBox.Show("Added successfully", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }else
                MessageBox.Show("Failed to add due to validations!", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);

        }
        private void AddGrade(object s, RoutedEventArgs e)
        {
            if (NewGrade.IsValid)
            {
                context.Grades.Add(NewGrade);
                context.SaveChanges();
                GetGrades();
                NewGrade = new Grade();
                AddNewGradeGrid.DataContext = NewGrade;
                MessageBox.Show("Added successfully", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Failed to add due to validations!", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void AddUniversity(object s, RoutedEventArgs e)
        {
            if (NewUniversity.IsValid)
            {
                context.Universities.Add(NewUniversity);
                context.SaveChanges();
                GetUniversities();
                NewUniversity = new University();
                AddNewUniversityGrid.DataContext = NewUniversity;
                MessageBox.Show("Added successfully", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Failed to add due to validations!", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void UpdateStudent(object s, RoutedEventArgs e)
        {
            if (selectedStudent.IsValid)
            {
                context.Update(selectedStudent);
                context.SaveChanges();
                GetStudents();
                selectedStudent = new Student();
                UpdateStudentGrid.IsEnabled = false;
                UpdateStudentGrid.DataContext = selectedStudent;
                MessageBox.Show("Updated successfully", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Failed to update due to validations!", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void UpdateGrade(object s, RoutedEventArgs e)
        {
            if (selectedGrade.IsValid)
            {
                context.Update(selectedGrade);
                context.SaveChanges();
                GetGrades();
                selectedGrade = new Grade();
                UpdateGradeGrid.IsEnabled = false;
                UpdateGradeGrid.DataContext = selectedGrade;
                MessageBox.Show("Updated successfully", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Failed to update due to validations!", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void UpdateUniversity(object s, RoutedEventArgs e)
        {
            if (selectedUniversity.IsValid)
            {
                context.Update(selectedUniversity);
                context.SaveChanges();
                GetUniversities();
                selectedUniversity = new University();
                UpdateUniversityGrid.IsEnabled = false;
                UpdateUniversityGrid.DataContext = selectedUniversity;
                MessageBox.Show("Updated successfully", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Failed to update due to validations!", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void SelectStudentForEdit(object s, RoutedEventArgs e)
        {
            selectedStudent = (s as FrameworkElement).DataContext as Student;
            UpdateStudentGrid.IsEnabled = true;
            UpdateStudentGrid.DataContext = selectedStudent;
        }
        private void SelectGradeForEdit(object s, RoutedEventArgs e)
        {
            selectedGrade = (s as FrameworkElement).DataContext as Grade;
            UpdateGradeGrid.IsEnabled = true;
            UpdateGradeGrid.DataContext = selectedGrade;
        }
        private void SelectUniversityForEdit(object s, RoutedEventArgs e)
        {
            selectedUniversity = (s as FrameworkElement).DataContext as University;
            UpdateUniversityGrid.IsEnabled = true;
            UpdateUniversityGrid.DataContext = selectedUniversity;
        }
        private void DeleteStudent(object s, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                var studentToDelete = (s as FrameworkElement).DataContext as Student;
                context.Students.Remove(studentToDelete);
                context.SaveChanges();
                GetStudents();
            }    
        }
        private void DeleteGrade(object s, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                var gradeToDelete = (s as FrameworkElement).DataContext as Grade;
                context.Grades.Remove(gradeToDelete);
                context.SaveChanges();
                GetGrades();
            }
        }
        private void DeleteUniversity(object s, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                var universityToDelete = (s as FrameworkElement).DataContext as University;
                context.Universities.Remove(universityToDelete);
                context.SaveChanges();
                GetUniversities();
            }
                
        }

        private void GradesDG_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void StudentDG_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
