# web-site

User for testing: 

login: Email_1@test.com
password: 1234

## [Frontend](./Frontend/README.md)

To run frontend app use steps below:

1. Go to `./Frontend` folder and run command to install node_modules:
    ```
    npm install
    ```
2. Run command to run the app:
    ```
    npm run start
    ```

## Database

For database used MSSQL server.

It is possible to run mssql server in Docker container. You need to have previously instlled [Docker Engine](https://docs.docker.com/engine/install/) on your computer. 
To run mssql-server container follow steps below (written for MacOS):

1. Go to `./Backend` folder and run command to build image:

    ```
    docker build -t mssql-server -f mssql-server.Dockerfile .
    ```
2. Than run docker image use command:
    ```
    docker run -p 1433:1433 --name mssql-server  -it mssql-server
    ```
Then use connection string with name "Docker" in `Program.cs` file.
