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
            // İlgili operasyon bilgisi alınır.
            var operation = await _operationReadRepository.GetByMachineIdAndOperationId(machineId, operationId);

            // İlgili makine için parametreler alınır.
            var parameters = _parameterReadRepository.GetParametersForMachine(machineId);

            // Her bir parametre için işlem yapılır.
            var updatedParameters = new Dictionary<string, int>();

            var parameterCounts = _parameterReadRepository.GetCountParameterByMachineIdAsync(machineId);

            foreach (var parameter in parameters)
            {
                // Belirli bir ParameterId için OperationParameters tablosundaki kayıtların sayısı kontrol edilir.
                var count = await _operationParameterReadRepository.GetCountByParameterId(parameter.Id);

                // Eğer 10'dan fazla parametre varsa, en eski kaydı (en düşük Id) siler.
                if (count >= 10)
                {
                    await _operationParameterWriteRepository.DeleteOldestOperationParameterByParameterId(parameter.Id);
                }

                // Yeni parametre değeri üretilir ve güncelleme listesine eklenir.
                var newValue = new Random().Next(35, 65);  // KALİTE KRİTER İÇİN PARAMETRE DEĞERİ BELİRLENEN ARALIKTA RANDOM ÜRETİLİR.
                updatedParameters.Add(parameter.ParameterName, newValue);

                // OperationParameters tablosuna yeni değer eklenir.
                _operationParameterWriteRepository.AddOperationParameter(operationId, parameter.Id, newValue.ToString());
            }

            // Tüm değişiklikler veritabanına kaydedilir.
            await _operationParameterWriteRepository.SaveAsync();

            // Güncellenen parametreler ve değerler döndürülür.
            return updatedParameters;
        }




    }
}
