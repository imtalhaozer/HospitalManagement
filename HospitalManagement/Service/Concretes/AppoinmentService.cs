using System.Net;
using HospitalManagement.Exceptions;
using HospitalManagement.Models;
using HospitalManagement.Models.Dtos.Request;
using HospitalManagement.Models.Dtos.Response;
using HospitalManagement.Repository.Concretes;
using HospitalManagement.Service.Abstracts;
using HospitalManagement.Service.Mappers;
using HospitalManagement.Validation;

namespace HospitalManagement.Service.Concretes;

public class AppoinmentService(AppoinmentRepository appoinmentRepository, 
    AppoinmentMapper appoinmentMapper, AppoinmentValidator appoinmentValidator) : IAppoinmentService
{
    public ReturnModel<Appoinment> Add(CreateAppoinmentRequest newObject) 
    {
        try
        {
            appoinmentValidator.ValidateAppoinment(newObject);
            Appoinment appoinmentObject= appoinmentMapper.ConvertToEntity(newObject);
            appoinmentRepository.Add(appoinmentObject);
            return new ReturnModel<Appoinment>()
            {
                Data = appoinmentObject,
                Success = true,
                Message = "Appoinment added",
                Code = HttpStatusCode.OK
            };
        }
        catch (AppointmentDateAlreadyExistsException ex)
        {
            return ReturnModelOfException<Appoinment>(ex);
        }
        
        catch (AppointmentNotAvailableException ex)
        {
            return ReturnModelOfException<Appoinment>(ex);
        }
        
        catch (InvalidAppointmentDayException ex)
        {
            return ReturnModelOfException<Appoinment>(ex);
        }
    }

    public ReturnModel<Appoinment> Update(CreateAppoinmentRequest newObject)
    {
        try
        {
            Appoinment appoinmentObject = appoinmentMapper.ConvertToEntity(newObject);
            appoinmentRepository.Update(appoinmentObject);
            return new ReturnModel<Appoinment>()
            {
                Data = appoinmentObject,
                Success = true,
                Message = "Appoinment updated",
                Code = HttpStatusCode.OK
            };
        }
        catch (Exception ex)
        {
           return ReturnModelOfException<Appoinment>(ex); 
        }
    }

    public ReturnModel<AppoinmentResponseDto> GetById(Guid id)
    {
        try
        {
            Appoinment? appoinmentObject=appoinmentRepository.GetById(id);
            AppoinmentResponseDto appoinment= appoinmentMapper.ConvertToResponse(appoinmentObject);
            return new ReturnModel<AppoinmentResponseDto>()
            {
                Data = appoinment,
                Success = true,
                Message = "Appoinment response",
                Code = HttpStatusCode.OK
            };
        }
        catch (Exception ex)
        {
            return ReturnModelOfException<AppoinmentResponseDto>(ex);
        }
    }

    public List<ReturnModel<AppoinmentResponseDto>> GetAll()
    {
        try
        {
            List<Appoinment> appoinmentList = appoinmentRepository.GetAll();
            
            List<AppoinmentResponseDto> appoinmentResponses = appoinmentList
                .Select(appoinment => appoinmentMapper.ConvertToResponse(appoinment))
                .ToList();
            
            return appoinmentResponses.Select(response => new ReturnModel<AppoinmentResponseDto>
            {
                Data = response,
                Success = true,
                Message = "Appoinment retrieved successfully.",
                Code = HttpStatusCode.OK
            }).ToList();
        }
        catch (Exception ex)
        {
            return new List<ReturnModel<AppoinmentResponseDto>>
            {
                ReturnModelOfException<AppoinmentResponseDto>(ex)
            };
        }
    }


    public ReturnModel<Appoinment> Delete(Guid id)
    {
        try
        {
            Appoinment? appoinment = appoinmentRepository.GetById(id);
            appoinmentRepository.Remove(appoinment);
            return new ReturnModel<Appoinment>()
            {
                Data = appoinment,
                Success = true,
                Message = "Appoinment deleted successfully.",
                Code = HttpStatusCode.OK
            };
        }
        catch (Exception ex)
        {
            return ReturnModelOfException<Appoinment>(ex);
        }
    }

    public ReturnModel<Appoinment> OutdatedAppointment()
    {
        try
        {
            List<Appoinment> outdatedAppointments = appoinmentRepository.GetAll()
                .Where(x => x.AppoinmentDate < DateTime.Now).ToList();
    
            if (outdatedAppointments.Any())
            {
                outdatedAppointments.ForEach(x => appoinmentRepository.Remove(x));
            }

            return new ReturnModel<Appoinment>()
            {
                Data = null,
                Success = true,
                Message = "Appoinment outdated",
                Code = HttpStatusCode.OK
            };
        }
        catch (Exception ex)
        {
            return ReturnModelOfException<Appoinment>(ex);
        }
    }

    private ReturnModel<T> ReturnModelOfException<T>(Exception ex)
    {
        if (ex.GetType() == typeof(NotFoundException))
        {
            return new ReturnModel<T>()
            {
                Data = default,
                Message = ex.Message,
                Success = false,
                Code = HttpStatusCode.NotFound
            };
        }

        if (ex.GetType() == typeof(ValidationException))
        {
            return new ReturnModel<T>()
            {
                Data = default,
                Message = ex.Message,
                Success = false,
                Code = HttpStatusCode.BadRequest
            };
        }

        if (ex.GetType() == typeof(AppointmentDateAlreadyExistsException))
        {
            return new ReturnModel<T>()
            {
                Data = default,
                Message = ex.Message,
                Success = false,
                Code = HttpStatusCode.Conflict
            };
        }

        if (ex.GetType() == typeof(AppointmentNotAvailableException))
        {
            return new ReturnModel<T>()
            {
                Data = default,
                Message = ex.Message,
                Success = false,
                Code = HttpStatusCode.BadRequest
            };
        }
    
        if (ex.GetType() == typeof(InvalidOperationException))
        {
            return new ReturnModel<T>()
            {
                Data = default,
                Message = ex.Message,
                Success = false,
                Code = HttpStatusCode.UnprocessableEntity
            };
        }

        return new ReturnModel<T>()
        {
            Data = default,
            Message = ex.Message,
            Success = false,
            Code = HttpStatusCode.InternalServerError
        };
    }
}