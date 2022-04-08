# MiniShop IDS


## 使用 dockerfile 构建部署

```shell
# 创建镜像
docker build -t minishopids -f Dockerfile .

# 启动容器
docker run -d -p 5001:80 --restart=always -v D:/dockervolumes/minishopids/appsettings.json:/app/appsettings.json -v D:/dockervolumes/minishopids/log:/app/log --name minishopids minishopids
```

注意：
在 windows 使用 docker desktop 容器部署时，各个容器挂载的 appsettings.json 中的 localhost 应该替换为 host.docker.internal。
docker 容器中的 localhost 是容器自身，容器要访问宿主机的话用 http://host.docker.internal，这个域名是 docker 安装时自动写到你的 hosts 文件中的，对应的就是你宿主机的 ip


