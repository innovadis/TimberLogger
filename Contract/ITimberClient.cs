using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace TimberClient.Contract
{
    public interface ITimberClient
    {
        Task Send(string log);

        Task Send(LogLevel logLevel, string category, string message);
    }
}