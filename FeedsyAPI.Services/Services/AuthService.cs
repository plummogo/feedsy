using FeedsyAPI.Data.Interfaces;
using FeedsyAPI.Data.Repositories;
using FeedsyAPI.Models;
using FeedsyAPI.Services.Interfaces;
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace FeedsyAPI.Services;

public class AuthService : IAuthService
{

    private readonly IGenericRepository<User> _userRepository;

    public AuthService(IGenericRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> GetUserByIdAsync(string userId)
    {
        return await _userRepository.GetByIdAsync(userId);
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _userRepository.GetAllAsync();
    }

    public async Task CreateUserAsync(User user)
    {
        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();
    }

    public async Task UpdateUserAsync(User user)
    {
        await _userRepository.UpdateAsync(user);
        await _userRepository.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(string userId)
    {
        await _userRepository.DeleteAsync(userId);
        await _userRepository.SaveChangesAsync();
    }
}
