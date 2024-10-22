using CombatCrittersSharp.managers;
using CombatCrittersSharp.objects.user;
using CombatCrittersSharp.rest;

namespace CombatCrittersSharp;

public interface IClient
{
    IRest Rest { get; }// rest handler for the client
    IUser? User { get; }// user 
    PackManager PackManager { get; }// pack manager for the client
    
    /// <summary>
    /// login the client with the provided username and password
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    Task Login(string username, string password);
    
    /// <summary>
    /// register a new user with the username and password, throws an error if the user already exists
    /// (still need to call login to log in the client)
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    Task Register(string username, string password);
}