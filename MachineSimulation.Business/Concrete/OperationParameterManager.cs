using MachineSimulation.Business.Abstract;
using MachineSimulation.DataAccess.Abstract.OperationParameterRepositories;
using MachineSimulation.DataAccess.Abstract.OperationRepositories;
using MachineSimulation.DataAccess.Abstract.ParameterRepositories;
using MachineSimulation.DataAccess.Concrete.OperationRepositories;
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
        private readonly IOperationReadRepository _operationReadRepository;
        private readonly IParameterReadRepository _parameterReadRepository;
        public OperationParameterManager(IOperationParameterReadRepository operationParameterReadRepository, IOperationParameterWriteRepository operationParameterWriteRepository, IOperationWriteRepository operationWriteRepository, IParameterReadRepository parameterReadRepository, IOperationReadRepository operationReadRepository)
        {
            _operationParameterReadRepository = operationParameterReadRepository;
            _operationParameterWriteRepository = operationParameterWriteRepository;
            _operationWriteRepository = operationWriteRepository;
            _parameterReadRepository = parameterReadRepository;
            _operationReadRepository = operationReadRepository;
        }
        public async Task<Dictionary<string, int>> StartProductionAsync(int machineId, int operationId)
        {
            // 'operationId' ve 'machineId' kullanılarak ilgili operasyon bilgisi alınır.
            var operation = await _operationReadRepository.GetByMachineIdAndOperationId(machineId, operationId);

            var updatedParameters = new Dictionary<string, int>();

            // İlgili makine için parametreler alınır.
            var parameters = _parameterReadRepository.GetParametersForMachine(machineId);

            foreach (var parameter in parameters)
            {
                var newValue = new Random().Next(0, 101);
                updatedParameters.Add(parameter.ParameterName, newValue);

                // 'OperationParameters' tablosunda, ilgili operasyon ve parametre için yeni değer kaydedilir.
                 _operationParameterWriteRepository.AddOperationParameter(operationId, parameter.Id, newValue.ToString());
            }

            // Tüm değişiklikler veritabanına kaydedilir.
            await _operationParameterWriteRepository.SaveAsync();

            // Güncellenen parametreler ve değerler döndürülür.
            return updatedParameters;
        }



    }
}
