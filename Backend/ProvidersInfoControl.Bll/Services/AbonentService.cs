using AutoMapper;
using ProvidersInfoControl.Bll.Localization;
using ProvidersInfoControl.Bll.Services.Interfaces;
using ProvidersInfoControl.Dal.Interfaces;
using ProvidersInfoControl.Domain.Dtos.Create;
using ProvidersInfoControl.Domain.Dtos.Get;
using ProvidersInfoControl.Domain.Dtos.Update;
using ProvidersInfoControl.Domain.Models;
using ProvidersInfoControl.Tools.Dtos;

namespace ProvidersInfoControl.Bll.Services;

public class AbonentService : AbstractService<AbonentCreateDto, AbonentUpdateDto, AbonentGetDto, Abonent>, IAbonentService
{
    private readonly IAbonentTypeRepository _abonentTypeRepository;

    public AbonentService(IMapper mapper, IAbonentRepository repository, IAbonentTypeRepository abonentTypeRepository) :
        base(mapper, repository)
    {
        _abonentTypeRepository = abonentTypeRepository;
    }

    public override async Task<IOperationResult> CreateAsync(params AbonentCreateDto[] dtos)
    {
        var models = Mapper.Map<Abonent[]>(dtos);

        var abonentTypes =  _abonentTypeRepository.GetQuery()
            .Where(x => models.Select(x => x.AbonentTypeId).Contains(x.Id));
        
        foreach (var model in models)
        {
            model.AbonentType = abonentTypes.FirstOrDefault(x => x.Id == model.AbonentTypeId);

            if (model.AbonentType == null)
                return OperationResult.Bad(string.Format(Errors.WrongAbonentTypeId, model.AbonentTypeId));
        }

        await Repository.Create(models);

        var getDtos = Mapper.Map<AbonentGetDto[]>(models);
        
        return OperationResult.Ok(getDtos);
    }

    public override async Task<IOperationResult> UpdateAsync(params AbonentUpdateDto[] dtos)
    {
        var models = Mapper.Map<Abonent[]>(dtos);

        var abonentTypes =  _abonentTypeRepository.GetQuery()
            .Where(x => models.Select(x => x.AbonentTypeId).Contains(x.Id));
        
        foreach (var model in models)
        {
            model.AbonentType = abonentTypes.FirstOrDefault(x => x.Id == model.AbonentTypeId);

            if (model.AbonentType == null)
                return OperationResult.Bad(string.Format(Errors.WrongAbonentTypeId, model.AbonentTypeId));
        }

        await Repository.Update(models);

        var getDtos = Mapper.Map<AbonentGetDto[]>(models);
        
        return OperationResult.Ok(getDtos);
    }
}