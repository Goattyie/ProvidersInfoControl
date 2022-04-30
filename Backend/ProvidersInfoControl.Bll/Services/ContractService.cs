using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProvidersInfoControl.Bll.Localization;
using ProvidersInfoControl.Bll.Services.Interfaces;
using ProvidersInfoControl.Dal.Interfaces;
using ProvidersInfoControl.Domain.Dtos.Create;
using ProvidersInfoControl.Domain.Dtos.Get;
using ProvidersInfoControl.Domain.Dtos.Update;
using ProvidersInfoControl.Domain.Models;
using ProvidersInfoControl.Tools.Dtos;

namespace ProvidersInfoControl.Bll.Services;

public class ContractService : AbstractService<ContractCreateDto, ContractUpdateDto, ContractGetDto, Contract>, IContractService
{
    private readonly IAbonentRepository _abonentRepository;
    private readonly IFirmRepository _firmRepository;

    public ContractService(IFirmRepository firmRepository, IAbonentRepository abonentRepository, IMapper mapper, IContractRepository repository) : base(mapper, repository)
    {
        _firmRepository = firmRepository;
        _abonentRepository = abonentRepository;
    }

    public override async Task<IOperationResult> CreateAsync(params ContractCreateDto[] dtos)
    {
        var models = Mapper.Map<Contract[]>(dtos);
        var firms = _firmRepository.GetQuery().Where(x => models.Select(m => m.FirmId).Contains(x.Id));
        var abonents = _abonentRepository.GetQuery().Where(x => models.Select(m => m.AbonentId).Contains(x.Id));

        foreach (var model in models)
        {
            var firm = await firms.FirstOrDefaultAsync(x => x.Id == model.FirmId);

            if (firm is null)
                return OperationResult.Bad(string.Format(Errors.WrongFirmId, model.FirmId));
            
            var abonent = await abonents.FirstOrDefaultAsync(x => x.Id == model.AbonentId);

            if (abonent is null)
                return OperationResult.Bad(string.Format(Errors.WrongAbonentId, model.AbonentId));

            model.Firm = firm;
            model.Abonent = abonent;
        }

        await Repository.Create(models);

        var getDtos = Mapper.Map<ContractGetDto[]>(models);
        
        return OperationResult.Ok(getDtos);
    }
    
    public override async Task<IOperationResult> UpdateAsync(params ContractUpdateDto[] dtos)
    {
        var models = Mapper.Map<Contract[]>(dtos);
        var firms = _firmRepository.GetQuery().Where(x => models.Select(m => m.FirmId).Contains(x.Id));
        var abonents = _abonentRepository.GetQuery().Where(x => models.Select(m => m.AbonentId).Contains(x.Id));

        foreach (var model in models)
        {
            var firm = await firms.FirstOrDefaultAsync(x => x.Id == model.FirmId);

            if (firm is null)
                OperationResult.Bad(string.Format(Errors.WrongFirmId, model.FirmId));
            
            var abonent = await abonents.FirstOrDefaultAsync(x => x.Id == model.AbonentId);

            if (abonent is null)
                OperationResult.Bad(string.Format(Errors.WrongAbonentId, model.AbonentId));

            model.Firm = firm;
            model.Abonent = abonent;
        }

        await Repository.Update(models);

        var getDtos = Mapper.Map<ContractGetDto[]>(models);
        
        return OperationResult.Ok(getDtos);
    }
}