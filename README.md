# MiniShop IDS


## 使用 dockerfile 构建部署

```shell
# 创建镜像
docker build -t minishopids -f Dockerfile .

# 启动容器
docker run -d -p 15101:80 --restart=always -v D:/dockervolumes/minishopids/appsettings.json:/app/appsettings.json -v D:/dockervolumes/minishopids/log:/app/log --name minishopids minishopids
```




