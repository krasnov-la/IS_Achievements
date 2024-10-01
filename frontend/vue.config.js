const { defineConfig } = require('@vue/cli-service')
module.exports = defineConfig({
  transpileDependencies: true,  
  // devServer: {
  //   proxy: {
  //       '/ctfapi': {
  //       target: process.env.VUE_APP_CTF_API,
  //       changeOrigin: true,
  //       ws: true,
  //       secure: true,
  //       // pathRewrite: { '^/ctfapi': '' },
  //     }
  //   }
  // }
})
