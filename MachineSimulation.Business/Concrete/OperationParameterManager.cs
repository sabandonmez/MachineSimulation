using MachineSimulation.Business.Abstract;
using MachineSimulation.DataAccess.Abstract.OperationParameterRepositories;
using MachineSimulation.DataAccess.Abstract.OperationRepositories;
using MachineSimulation.DataAccess.Abstract.ParameterRepositories;
using MachineSimulation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSimulation.Business.Concrete
{
    public class OperationParameterManager :IOperationParameterService
    {
        private readonly IOperationParameterReadRepository _operationParameterReadRepository;
        private readonly IOperationParameterWriteRepository _operationParameterWriteRepository;
        private readonly IOperationWriteRepository _operationWriteRepository;
        private readonly IParameterReadRepository _parameterReadRepository;
        public OperationParameterManager(IOperationParameterReadRepository operationParameterReadRepository, IOperationParameterWriteRepository operationParameterWriteRepository, IOperationWriteRepository operationWriteRepository, IParameterReadRepository parameterReadRepository)
        {
            _operationParameterReadRepository = operationParameterReadRepository;
            _operationParameterWriteRepository = operationParameterWriteRepository;
            _operationWriteRepository = operationWriteRepository;
            _parameterReadRepository = parameterReadRepository;
        }
        public async Task<Dictionary<string, int>> StartProductionAsync(int machineId)
        {
            var operation = new Operation { MachineId = machineId, OperationName = "Üretim Başlat" };
            await _operationWriteRepository.AddAsync(operation);
            await _operationWriteRepository.SaveAsync();

            var updatedParameters = new Dictionary<string, int>();

            var parameters = _parameterReadRepository.GetParametersForMachine(machineId);
            foreach (var parameter in parameters)
            {
                var randomValue = new Random().Next(0, 101);
                updatedParameters.Add(parameter.ParameterName, randomValue);

                // ToString() kullanmanıza gerek yok, eğer değer zaten int ise doğrudan kullanılabilir.
                _operationParameterWriteRepository.AddOperationParameter(operation.Id, parameter.Id, randomValue.ToString());
            }

            await _operationParameterWriteRepository.SaveAsync();

            // Güncellenen parametrelerin değerlerini içeren sözlüğü döndür
            return updatedParameters;
        }

    }
}
