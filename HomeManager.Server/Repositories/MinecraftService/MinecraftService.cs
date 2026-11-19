using System.Net.Sockets;
using System.Text;

namespace HomeManager.Server.Repositories;

public class MinecraftService
{
    public async Task<string> PingServerAsync(string serverIp, int port = 25565, int timeoutMs = 5000)
    {
        using TcpClient client = new();
        var connectTask = client.ConnectAsync(serverIp, port);

        if (await Task.WhenAny(connectTask, Task.Delay(timeoutMs)) != connectTask)
        {
            throw new TimeoutException("Connection timed out");
        }

        await connectTask;

        using NetworkStream stream = client.GetStream();
        using BinaryWriter writer = new(stream);
        using BinaryReader reader = new(stream);

        // handshake
        writer.Write((byte)0x00); // Packet ID
        writer.Write((byte)0x04); // Protocol version (1.20.4)
        writer.Write((byte)serverIp.Length); // Server IP length
        writer.Write(Encoding.UTF8.GetBytes(serverIp)); // Server IP
        writer.Write((short)port); // Port (big-endian)
        writer.Write((byte)0x01); // Next state (1 for status)

        //status request
        writer.Write((byte)0x00); // Packet ID
        writer.Write((byte)0x00); // Empty payload

        // Read response
        byte packetId = reader.ReadByte();
        if (packetId != 0x00) throw new Exception("Invalid packet ID");

        int length = ReadVarInt(reader);
        byte[] response = reader.ReadBytes(length);
        string jsonResponse = Encoding.UTF8.GetString(response);

        return jsonResponse;
    }

    private static int ReadVarInt(BinaryReader reader)
    {
        int value = 0;
        int length = 0;
        byte currentByte;

        while (true)
        {
            currentByte = reader.ReadByte();
            value |= (currentByte & 0x7F) << (length * 7);
            length += 1;

            if (length > 5) throw new Exception("VarInt is too big");
            if ((currentByte & 0x80) == 0) break;
        }

        return value;
    }
}
