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
        private HttpClient httpClient;
        private String clientUrl;

        public String User 
        {
            get { return patientModel.User; }
            set { patientModel.User = value; } 
        }
        public String Forename
        {
            get { return patientModel.Forename; }
            set { patientModel.Forename = value; }
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
            get { return patientModel.Postcode; }
            set { patientModel.Postcode = value; }
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
                Forename = "",
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
            clientUrl = "/api/Patient";
            httpClient.BaseAddress = new Uri("http://localhost:5000");
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
                Forename = patientModel.Forename,
                Surname = patientModel.Surname,
                DateOfBirth = patientModel.DateOfBirth,
                PrimaryContactNumber = patientModel.Phone,
                PrimaryAddressLine1 = patientModel.AddrLine1,
                PrimaryAddressLine2 = patientModel.AddrLine2,
                PrimaryAddressLine3 = patientModel.AddrLine3,
                PostCode = patientModel.Postcode
            };

            var requestJSON = JsonConvert.SerializeObject(reqModel, Formatting.Indented);
            var start = DateTime.Now;
            var response = await httpClient.PostAsync(clientUrl, new StringContent(requestJSON, Encoding.UTF8, "application/json"));
            //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, clientUrl);
            //var response = await httpClient.SendAsync(request);
            string responseBody = await response.Content.ReadAsStringAsync();
            TimeSpan timeDiff = DateTime.Now - start;
            Response = string.Format("Elapsed={0}mS Status = {1} - {2}", timeDiff.TotalMilliseconds, response.StatusCode, responseBody );
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
