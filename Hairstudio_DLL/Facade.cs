using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hairstudio_DLL.GatewayService;
using HSRestAPI_DLL.Entities;

namespace Hairstudio_DLL
{
    public class Facade
    {
        private IGatewayService<Hairdresser> _hairdresserGateway;
        private IGatewayService<Appointment> _appointmentGateway;
        private IGatewayService<Customer> _customerGateway;
        private IGatewayService<TimeRange> _timeRangeGateway;
        private IGatewayService<Message> _messageGateway;
        private IGatewayService<ServiceOffered> _serviceOfferedGateway;


        public IGatewayService<Hairdresser> GetHairdresserGateway()
        {
            return _hairdresserGateway ?? (_hairdresserGateway = new HairdresserGateway());
        }

        public IGatewayService<Appointment> GetAppointmentGateway()
        {
            return _appointmentGateway ?? (_appointmentGateway = new AppointmentGateway());
        }
        public IGatewayService<Customer> GetCustomerGateway()
        {
            return _customerGateway ?? (_customerGateway = new CustomerGateway());
        }
        public IGatewayService<TimeRange> GetTimeRangeGateway()
        {
            return _timeRangeGateway ?? (_timeRangeGateway = new TimeRangeGateway());
        }
        public IGatewayService<Message> GetMessageGateway()
        {
            return _messageGateway ?? (_messageGateway = new MessageGateway());
        }
        public IGatewayService<ServiceOffered> GetServiceOfferedGateway()
        {
            return _serviceOfferedGateway ?? (_serviceOfferedGateway = new ServiceOfferedGateway());
        }
    }
}
