using GuiClient.Http;
using GuiClient.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;

namespace GuiClient.ViewModel
{
    class PatientViewModel : INotifyPropertyChanged
    {
        private PatientModel patientModel;
        //private APIClient apiClient;
        private HttpClient httpClient;
        private String clientUrl;

        public String User 
        {
            get { return patientModel.User; }
            set { patientModel.User = value; } 
        }
        public String ForeName
        {
            get { return patientModel.ForeName; }
            set { patientModel.ForeName = value; }
        }
        public String Surname
        {
            get { return patientModel.Surname; }
            set { patientModel.Surname = value; }
        }

        public String DateOfBirth
        {
            get { return patientModel.DateOfBirth; }
            set { patientModel.DateOfBirth = value; }
        }
        public String Phone
        {
            get { return patientModel.Phone; }
            set { patientModel.Phone = value; }
        }

        public String AddrLine1
        {
            get { return patientModel.AddrLine1; }
            set { patientModel.AddrLine1 = value; }
        }

        public String AddrLine2
        {
            get { return patientModel.AddrLine2; }
            set { patientModel.AddrLine2 = value; }
        }

        public String AddrLine3
        {
            get { return patientModel.AddrLine3; }
            set { patientModel.AddrLine3 = value; }
        }

        public String Postcode
        {
            get { return patientModel.DateOfBirth; }
            set { patientModel.DateOfBirth = value; }
        }

        public String Response
        {
            get { return patientModel.Response; }
            set { patientModel.Response = value; OnPropertyChange("Response"); }
        }


        public PatientViewModel()
        {
            patientModel = new PatientModel
            {
                User = "",
                ForeName = "",
                Surname = "",
                DateOfBirth = "",
                Phone = "",
                AddrLine1 = "",
                AddrLine2 = "",
                AddrLine3 = "",
                Postcode = "",
                Response = ""
            };

            httpClient = new HttpClient();
            clientUrl = "http://localhost:5000/api/Patient";
            //apiClient = new APIClient("http://localhost:5000/api/Patient");
        }


        private RelayCommand<object> _commandStart;
        public ICommand CmdSubmitPressed
        {
            get
            {
                if (_commandStart == null)
                {
                    _commandStart = new RelayCommand<object>(param => Start(), param => CanStart());
                }
                return _commandStart;
            }
        }

        public async void Start()
        {
            APIModel reqModel = new APIModel
            {
                User = patientModel.User,
                ForeName = patientModel.ForeName,
                Surname = patientModel.Surname,
                DateOfBirth = patientModel.DateOfBirth,
                PrimaryContactNumber = patientModel.Phone,
                PrimaryAddressLine1 = patientModel.AddrLine1,
                PrimaryAddressLine2 = patientModel.AddrLine2,
                PrimaryAddressLine3 = patientModel.AddrLine3,
                PostCode = patientModel.Postcode
            };
            var requestJSON = JsonConvert.SerializeObject(reqModel);

            var response = await httpClient.PostAsync(clientUrl, new StringContent(requestJSON, Encoding.UTF8, "application/json"));
            
            patientModel.Response = string.Format("Status = {0} - {1}", response.StatusCode, response.Content);

            //var response = await apiClient.SendRequest(reqModel);
            //patientModel.Response = response;
        }

        public bool CanStart()
        {
            return true;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
