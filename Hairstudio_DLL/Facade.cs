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

        public IGatewayService<Hairdresser> GetHairdresserGateway()
        {
            return _hairdresserGateway ?? (_hairdresserGateway = new HairdresserGateway());
        }

        public IGatewayService<Appointment> GetAppointmentGateway()
        {
            return _appointmentGateway ?? (_appointmentGateway = new AppointmentGateway());
        }
    }
}
