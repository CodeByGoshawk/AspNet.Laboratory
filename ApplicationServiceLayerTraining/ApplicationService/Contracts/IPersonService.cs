﻿using ApplicationServiceLayerTraining.ApplicationService.Contracts.ServiceFrameworks;
using ApplicationServiceLayerTraining.ApplicationService.Dtos.PersonDtos;
using ApplicationServiceLayerTraining.Models.DomainModels.PersonAggregates;

namespace ApplicationServiceLayerTraining.ApplicationService.Contracts;

public interface IPersonService : IService<Person,ServiceCreatePersonDto,ServiceSelectPersonDto,ServiceUpdatePersonDto,ServiceDeletePersonDto>
{
    Task<ServiceSelectPersonDto?> SelectByNationalCodeAsync(string nationalCode);
}
