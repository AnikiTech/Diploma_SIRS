var env = process.env.NODE_ENV || 'development'

var config = {
  development: require('./dev.env.js'),
  production: require('./prod.env.js')
}

module.exports = config[env]