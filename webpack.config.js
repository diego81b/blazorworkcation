const path = require("path");
const MiniCssExtractPlugin = require("mini-css-extract-plugin");

const bundleFileName = "blazortest";
const dirName = "BlazorApp.Web/wwwroot/dist";

module.exports = (env, argv) => {
    return {
        mode: argv.mode === "production" ? "production" : "development",
        entry: ["./BlazorApp.Web/wwwroot/js/app.js", "./BlazorApp.Web/wwwroot/css/tailwind.css"],
        output: {
            filename: bundleFileName + ".js",
            path: path.resolve(__dirname, dirName)
        },
        module: {
            rules: [{
                test: /\.css$/,
                use: [
                    MiniCssExtractPlugin.loader,
                    "css-loader",
                    "postcss-loader"
                ]
            }]
        },
        plugins: [
            new MiniCssExtractPlugin({
                filename: bundleFileName + ".css"
            })
        ]
    };
};