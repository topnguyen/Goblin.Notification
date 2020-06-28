# Docker Build and Run

docker build --tag goblin-notification:1.0 .

docker run --network bridge --publish 8001:80 --env-file DockerEnv --detach --name goblin-notification goblin-notification:1.0

---

# Docker Remove

docker rm --force goblin-notification

---

# Network

docker network ls

docker network create -d bridge goblin

docker network inspect goblin

docker network rm goblin