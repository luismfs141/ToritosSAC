import React from "react";
import '../assetss/css/Login.css';
import logo from '../assetss/img/User.png';
import {Apiurl} from '../services/apirest';
import axios from 'axios';

class Login extends React.Component{

    manejadorSubmit(e){
        e.preventDefault();
    }

    manejadorChange = async e=>{
        await this.setState ({
            form:{
                ...this.state.form,
                [e.target.name] : e.target.value
            }
        });
        console.log(this.state.form)
    }

    manejadorBoton(){
        let url = Apiurl + "Cliente/LoginCliente";
        axios.post(url)
        .then(response =>{
            console.log(response);
        })
    }

    state={
        form:{
            "usuario:":"",
            "password:":""
        },
        error:false,
        errorMsg:""
    }

    render(){
        return(
            <React.Fragment>
                <div className="wrapper fadeInDown">
                    <div id="formContent">
                        <div className="fadeIn first">
                        <img src={logo} width="100px" alt="User Icon" />
                        </div>


                        <form onSubmit={this.manejadorSubmit}>
                        <input type="text" className="fadeIn second" name="usuario" placeholder="Usuario" onChange={this.manejadorChange}/>
                        <input type="password" className="fadeIn third" name="password" placeholder="Password" onChange={this.manejadorChange}/>
                        <input type="submit" className="fadeIn fourth" value="Log In" onClick={this.manejadorBoton}/>
                        </form>

                        <div id="formFooter">
                        <a className="underlineHover" href="#">Forgot Password?</a>
                        </div>

                    </div>
                </div>
            </React.Fragment>
        );
    }
}

export default Login