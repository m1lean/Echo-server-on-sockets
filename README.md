
# The simplest echo server on sockets

This code implements a **simple TCP echo server** in C#. Here's what it does:

1. **Creates a socket listener**:
   - The server initializes a `Socket` to listen for incoming client connections on port `5000`.

2. **Binds and listens for connections**:
   - It binds the socket to any available network interface (`IPAddress.Any`) and starts listening for client connections, allowing up to 5 simultaneous pending connection requests.

3. **Accepts client connections**:
   - Once a client connects, the server accepts the connection and starts interacting with the client.

4. **Receives and echoes messages**:
   - The server reads incoming messages from the client using the `Receive` method.
   - It converts the received bytes into a string using UTF-8 encoding.
   - If the received message is "exit" (case-insensitive), the server closes the connection with that client.
   - Otherwise, the server responds with an echo message (`"Echo: <client's message>"`) and sends it back to the client.

5. **Handles client disconnection**:
   - When a client sends "exit", the server breaks out of the loop for that connection and closes the client socket.

6. **Runs continuously**:
   - The server operates in an infinite loop, waiting for new clients to connect, while serving existing clients sequentially.










