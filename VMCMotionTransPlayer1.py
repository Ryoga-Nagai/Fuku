from socket import AF_INET, SOCK_DGRAM, socket

HOST = ''

R_PORT = 5001
S_PORT = 5052

r_s = socket(AF_INET, SOCK_DGRAM)
s_s = socket(AF_INET, SOCK_DGRAM)
r_s.bind((HOST,R_PORT))

try:
    while True:
        msg,address = r_s.recvfrom(8192)

        #print(msg)

        s_s.sendto(msg,("192.168.11.175",5051))#相手端末のIPアドレスを入れる
        s_s.sendto(msg,("127.0.0.1",39539))

finally:
    s_s.close()
    r_s.close()
