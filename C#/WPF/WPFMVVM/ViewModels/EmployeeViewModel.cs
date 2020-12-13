using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using WPFMVVM.Commands;
using WPFMVVM.Models;
namespace WPFMVVM.ViewModels
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged_Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion  

        EmployeeService ObjEmployeeService;
        public EmployeeViewModel()
        {
            ObjEmployeeService = new EmployeeService();
            LoadData();
            currentEmployee = new Employee();
            saveCommand = new RelayCommand(Save);
            searchCommand = new RelayCommand(Search);
        }

        #region DisplayOperation
        private ObservableCollection<Employee> employees;

        public ObservableCollection<Employee> EmployeesList
        {
            get { return employees; }
            set { employees = value; OnPropertyChanged("EmployeesList"); }
        }

        private void LoadData()
        {
            EmployeesList =new ObservableCollection<Employee>( ObjEmployeeService.GetAll());
        }
        #endregion

        private Employee currentEmployee;
        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }

        public Employee CurrentEmployee
        {
            get { return currentEmployee; }
            set { currentEmployee = value; OnPropertyChanged("CurrentEmployee"); }
        }

        private RelayCommand saveCommand;

        public RelayCommand SaveCommand
        {
            get { return saveCommand; }            
        }

        public void Save()
        {
            try
            {
                var IsSaved = ObjEmployeeService.Add(CurrentEmployee);
                LoadData();
                if (IsSaved)
                    Message = "Employee saved";
                else
                    Message = "Save operation failed";
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }

        #region SearchOperation
        private RelayCommand searchCommand;

        public RelayCommand SearchCommand
        {
            get { return searchCommand; }            
        }

        public void Search()
        {
            try
            {
                var ObjEmployee = ObjEmployeeService.Search(currentEmployee.Id);
                if(ObjEmployee !=null)
                {
                    currentEmployee.Name = ObjEmployee.Name;
                    currentEmployee.Age = ObjEmployee.Age;
                }
                else
                {
                    Message = "Employee Not fount";
                }
            }
            catch (Exception ex)
            {
                
            }
        }


        #endregion

    }
}
