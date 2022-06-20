from socket import AF_INET, SOCK_DGRAM, socket

HOST = ''

RECEIVE_PORT = 5002
PARTNER_PORT = 5051
MY_APP_PORT  = 39539

receive_socket = socket(AF_INET, SOCK_DGRAM)
send_socket = socket(AF_INET, SOCK_DGRAM)
receive_socket.bind((HOST, RECEIVE_PORT))

try:
    while True:
        msg,address = receive_socket.recvfrom(8192)

        send_socket.sendto(msg,("192.168.11.180", PARTNER_PORT)) # 相手端末のIPアドレスを入れる
        send_socket.sendto(msg,("localhost", MY_APP_PORT))
finally:
    send_socket.close()
    receive_socket.close()
