const PROXY_CONFIG = [
  {
    context: [
      "/home",
      "/home/getemaillist"
    ],
    target: "https://localhost:7014",
    secure: false,
  }
]

module.exports = PROXY_CONFIG;
