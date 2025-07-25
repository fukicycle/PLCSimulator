using System;

namespace Domain.Interfaces;

public interface IPLCSimulatorService
{
    void StartPLCSimulator(int port);
}
