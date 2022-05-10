using AutoMapper;
using CabinetDentaire.API.Models.Appointments;
using CabinetDentaire.API.Models.Cancellations;
using CabinetDentaire.API.Models.Consultations;
using CabinetDentaire.API.Models.Dentistes;
using CabinetDentaire.API.Models.Patients;
using CabinetDentaire.Shared.Entities;

namespace CabinetDentaire.API.Helpers
{
    public class MappingProfile :Profile 
    {
        public MappingProfile()
        {
            //For Appointment
            CreateMap<AppointmentForCreation, Appointment>();
            CreateMap<Appointment, AppointmentForDetailsConsultation>();
            CreateMap<Appointment, AppointmentDetails>()
                .ForMember(dest => dest.Dentiste, opt => opt.MapFrom(src => $"{src.Dentiste.Name}"))
                .ForMember(dest => dest.Patient, opt => opt.MapFrom(src => $"{src.Patient.Name}"));

            //For patients
            CreateMap<PatientForCreation, Patient>();
            CreateMap<Patient,PatientDetails >();
            CreateMap<Patient,PatientWithConsultation >();


            //For Consultation
            CreateMap<ConsultationForCreation , Consultation>();
            CreateMap<Consultation, ConsultationDetails>();


            //For Dentiste 
            CreateMap<Dentiste, DentisteDetails>();
            CreateMap<DentisteForUpdate, WorkCategory>();


            //for Cancellation 
            CreateMap<CancellationForCreation , Cancellation>();
            CreateMap<Cancellation, CancellationDetails>();

        }
    }
}
