using Application.Services;
using Infrastructure.Mitsubishi;
using Infrastructure.Mitsubishi.ACompatible1EFrame;
var messageLoggerService = new MessageLoggerService();
var serverInstances = new List<IDisposable>();
int[] ports = [3001, 3025];
foreach (var port in ports)
{
    var simulator = new MelsecAPLCSimulatorService(
        messageLoggerService,
        new MessageHandlingService(
            new ACompatible1EFrameRequestMessageProcessorService()));
    serverInstances.Add(simulator);
    simulator.StartPLCSimulator(port);
}
Console.ReadLine();
foreach (var serverInstance in serverInstances)
{
    serverInstance.Dispose();
}