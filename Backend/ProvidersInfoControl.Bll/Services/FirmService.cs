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

public class FirmService : AbstractService<FirmCreateDto, FirmUpdateDto, FirmGetDto, Firm>, IFirmService
{
    private readonly IOwnTypeRepository _ownTypesRepository;

    public FirmService(IOwnTypeRepository ownTypesRepository, IMapper mapper, IFirmRepository repository)
        : base(mapper, repository)
    {
        _ownTypesRepository = ownTypesRepository;
    }

    public override async Task<IOperationResult> CreateAsync(params FirmCreateDto[] dtos)
    {
        var models = Mapper.Map<Firm[]>(dtos);
        var ownTypes = _ownTypesRepository.GetQuery().Where(x => models.Select(m => m.OwnTypeId).Contains(x.Id));

        foreach (var model in models)
        {
            var ownType = await ownTypes.FirstOrDefaultAsync(x => x.Id == model.OwnTypeId);

            if (ownType is null)
                return OperationResult.Bad(string.Format(Errors.WrongOwnTypeId, model.OwnTypeId));

            model.OwnType = ownType;
        }

        await Repository.Create(models);

        var getDtos = Mapper.Map<FirmGetDto[]>(models);
        
        return OperationResult.Ok(getDtos);
    }
    
    public override async Task<IOperationResult> UpdateAsync(params FirmUpdateDto[] dtos)
    {
        var models = Mapper.Map<Firm[]>(dtos);
        var ownTypes = _ownTypesRepository.GetQuery().Where(x => models.Select(m => m.OwnTypeId).Contains(x.Id));

        foreach (var model in models)
        {
            var ownType = await ownTypes.FirstOrDefaultAsync(x => x.Id == model.OwnTypeId);

            if (ownType is null)
                return OperationResult.Bad(string.Format(Errors.WrongOwnTypeId, model.OwnTypeId));

            model.OwnType = ownType;
        }

        await Repository.Update(models);

        var getDtos = Mapper.Map<FirmGetDto[]>(models);
        
        return OperationResult.Ok(getDtos);
    }
}