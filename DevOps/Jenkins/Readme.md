## ����Ŀ��
����docker���ٴ���ڲ���Ŀ�ĵ�Jenkis������

## ����˵��
- Windows 10 v1803
- Docker Version 18.03.1-ce-win65 

## ׼��
- ����docker
- ��ȡ����jenkinsci/blueocean
- ��CMD��ִ��������������jenkins
``` cmd
docker run ^
-u root ^
--rm ^
-d ^
-p 8080:8080 ^
-p 50000:50000 ^
-v jenkins-data:/var/jenkins_home ^
-v /var/run/docker.sock:/var/run/docker.sock ^
--name jenkins-blueocean ^
jenkinsci/blueocean
```
- ��һ������ʱ���������־�л�ȡ�������룬��docker�п���ͨ��dockerM��������־��ȡ������jenkins��docker��־
```
docker logs jenkins-blueocean
```
��Ӧ�����ڣ�

![1](1.png)

- ���������������http://localhost:8080���״η���jenkins���������½��棬��Ҫ�������ʣ�����Ϊ�ϲ��л�ȡ�����룻
![2](2.png)
- Jenkins������׼�������ɿ�ʼʹ��