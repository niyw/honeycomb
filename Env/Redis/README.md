## 环境说明
- Windows 10 v1803
- Docker Version 18.03.1-ce-win65 

## 使用说明:
- 打开命令行，切换到此目录
- 运行命令: 
```cmd
docker-compose up
```
- 使用Psping执行psping localhost:6379,检查是否正常
- 完成


## 其他
- docker pull redis:4
- 官方镜像默认无法从外部连接，所以才使用docker-compose
