﻿using SinglePageArchitectureTraining.ApplicationService.Contracts.ServiceFrameworks;
using SinglePageArchitectureTraining.ApplicationService.Dtos.PersonDtos;

namespace SinglePageArchitectureTraining.ApplicationService.Contracts;

public interface IPersonService : IService<ServiceCreatePersonDto, ServiceSelectPersonDto, ServiceSelectAllPersonsDto, ServiceUpdatePersonDto, ServiceDeletePersonDto>
{
}