using DongHoLePhuocHai.Models;

namespace DongHoLePhuocHai.Services;

public interface IFamilyService
{
    Task<ApiResponse<List<FamilyMemberDto>>> GetAllMembersAsync();
    Task<ApiResponse<FamilyMemberDto>> GetMemberByIdAsync(int id);
    Task<ApiResponse<FamilyMemberDto>> CreateMemberAsync(FamilyMemberDto member);
    Task<ApiResponse<FamilyMemberDto>> UpdateMemberAsync(FamilyMemberDto member);
    Task<ApiResponse<bool>> DeleteMemberAsync(int id);
} 