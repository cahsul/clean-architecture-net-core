//Import the modules needed for our configuration
import globby from 'globby';
import babel from '@rollup/plugin-babel';
import commonjs from '@rollup/plugin-commonjs';
import nodeResolve from '@rollup/plugin-node-resolve';
import path from 'path';

export default {

    input: globby.sync(['../SharedPage/**/*.js', '../Pages/**/*.js']),
    output: {

        //The root folder for all bundled .js files
        dir: 'js-page/', 

        // bundle the files as ES modules
        format: 'es',

        entryFileNames: ({ facadeModuleId }) => {


            let root = path.resolve('.');
            //let filePath = path.parse(facadeModuleId.substr(-(facadeModuleId.length - root.length) + -1));
            let filePath = path.parse(facadeModuleId.substr(root.replace("\wwwroot", "").length));

            let fileName = `${filePath.dir}/[name].js`;

            //console.log(fileName);
            //console.log(filePath.dir);
            //console.log(path.resolve('.'));
            //console.log(facadeModuleId);
            //console.log(facadeModuleId.substr(root.replace("\wwwroot","").length) );
            //console.log(path.parse(facadeModuleId.substr(root.replace("\wwwroot","").length)).dir );
            //return;
            //console.log(facadeModuleId.replace("\Client", "\Client\\wwwroot") ); return;
            //return facadeModuleId.replace("\Client", "\Client\\wwwroot\\js");

            console.log(fileName);
            return fileName;
        }
    },
    plugins: [
        nodeResolve(),
        commonjs({
            include: "node_modules/**"
        }),
        babel({
            babelHelpers: 'bundled',
        }),
    ]
};