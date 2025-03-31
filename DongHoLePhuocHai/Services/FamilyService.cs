using DongHoLePhuocHai.Models;

namespace DongHoLePhuocHai.Services;

public class FamilyService : IFamilyService
{
    private readonly IApiService _apiService;
    private const string BaseEndpoint = "api/family";

    public FamilyService(IApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<ApiResponse<List<FamilyMemberDto>>> GetAllMembersAsync()
    {
        try
        {
            var members = await _apiService.GetAsync<List<FamilyMemberDto>>($"{BaseEndpoint}/members");
            return ApiResponse<List<FamilyMemberDto>>.CreateSuccess(members ?? new List<FamilyMemberDto>());
        }
        catch (Exception ex)
        {
            return ApiResponse<List<FamilyMemberDto>>.CreateError(ex.Message);
        }
    }

    public async Task<ApiResponse<FamilyMemberDto>> GetMemberByIdAsync(int id)
    {
        try
        {
            var member = await _apiService.GetAsync<FamilyMemberDto>($"{BaseEndpoint}/members/{id}");
            return ApiResponse<FamilyMemberDto>.CreateSuccess(member);
        }
        catch (Exception ex)
        {
            return ApiResponse<FamilyMemberDto>.CreateError(ex.Message);
        }
    }

    public async Task<ApiResponse<FamilyMemberDto>> CreateMemberAsync(FamilyMemberDto member)
    {
        try
        {
            var createdMember = await _apiService.PostAsync<FamilyMemberDto>($"{BaseEndpoint}/members", member);
            return ApiResponse<FamilyMemberDto>.CreateSuccess(createdMember);
        }
        catch (Exception ex)
        {
            return ApiResponse<FamilyMemberDto>.CreateError(ex.Message);
        }
    }

    public async Task<ApiResponse<FamilyMemberDto>> UpdateMemberAsync(FamilyMemberDto member)
    {
        try
        {
            var updatedMember = await _apiService.PutAsync<FamilyMemberDto>($"{BaseEndpoint}/members/{member.Id}", member);
            return ApiResponse<FamilyMemberDto>.CreateSuccess(updatedMember);
        }
        catch (Exception ex)
        {
            return ApiResponse<FamilyMemberDto>.CreateError(ex.Message);
        }
    }

    public async Task<ApiResponse<bool>> DeleteMemberAsync(int id)
    {
        try
        {
            var result = await _apiService.DeleteAsync($"{BaseEndpoint}/members/{id}");
            return ApiResponse<bool>.CreateSuccess(result);
        }
        catch (Exception ex)
        {
            return ApiResponse<bool>.CreateError(ex.Message);
        }
    }
} 