module.exports = {
    server: {
        port        : process.env.PORT || 3000,
        ip          : process.env.IP || '127.0.0.1',
        domains     : [ 'localhost:3000' ],
        cur_domain  : 0
    }
};
