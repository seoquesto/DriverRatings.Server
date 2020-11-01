db.auth('root', 'secret');
db = db.getSiblingDB('DriverRatingsDB');
db.createUser(
  {
    user: 'mongo-user',
    pwd: 'mongo-password',
    roles: [{ role: 'dbOwner', db: 'DriverRatingsDB' }],
  },
);
