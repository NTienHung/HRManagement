using HRPrinterApp.Commands;
using HRPrinterApp.Models;
using HRPrinterApp.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPrinterApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private EmployeeRepository _employeeRepository;
        public ObservableCollection<Employee> AllEmployees { get; set; }
        public ObservableCollection<Employee> Employees { get; set; }
        public RelayCommand LoadCommand { get; set; }
        public RelayCommand AddCommand { get; set; }
        public string SearchText { get; set; }
        public RelayCommand SearchCommand { get; set; }
        public ObservableCollection<Department> Departments { get; set; }
        private Department _selectedDepartment; 
        private Employee _selectedEmployee;
        public RelayCommand DeleteCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public MainViewModel()
        {
            _employeeRepository = new EmployeeRepository();

            Employees = new ObservableCollection<Employee>();
            AllEmployees = new ObservableCollection<Employee>();
            Departments = new ObservableCollection<Department>();

            LoadCommand = new RelayCommand(LoadEmployees);
            AddCommand = new RelayCommand(AddEmployee);
            DeleteCommand = new RelayCommand(DeleteEmployee);

            LoadDepartments();
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Employee SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged(nameof(SelectedEmployee));
            }
        }

        public Department SelectedDepartment
        {
            get => _selectedDepartment;
            set
            {
                _selectedDepartment = value;
                ApplyFilter();
            }
        }

        private void LoadDepartments()
        {
            var list = _employeeRepository.GetDepartments();

            Departments.Clear();

            foreach (var d in list)
            {
                Departments.Add(d);
            }
        }

        private void LoadEmployees()
        {
            Employees.Clear();
            AllEmployees.Clear();

            var list = _employeeRepository.GetAll();

            foreach (var emp in list)
            {
                Employees.Add(emp);
                AllEmployees.Add(emp);
            }
        }

        private void AddEmployee()
        {
            var employee = new Employee
            {
                Name = "New Employee",
                DepartmentId = 1
            };

            _employeeRepository.Add(employee);

            LoadEmployees();
        }

        private void ApplyFilter()
        {
            Employees.Clear();

            var filtered = AllEmployees
                .Where(e => SelectedDepartment == null
                            || e.DepartmentId == SelectedDepartment.Id)
                .ToList();

            foreach (var emp in filtered)
            {
                Employees.Add(emp);
            }
        }

        private void DeleteEmployee()
        {
            if (SelectedEmployee == null)
                return;

            _employeeRepository.Delete(SelectedEmployee.Id);

            Employees.Remove(SelectedEmployee);
            AllEmployees.Remove(SelectedEmployee);
        }

    }
}
