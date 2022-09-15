
import React, { Component } from 'react';
import { Container, Col, Form, Row, FormGroup, Label, Input, Button } from 'reactstrap';


export class AddStudent extends Component {
    constructor(props) {
        super(props)
        this.state = {
            Students: [],
             id: 0,
            name: "",
            age: "",
            PhoneNumber: "",
            Addres: ""
        }
    }
    createClick() {
        fetch('https://localhost:7033/api/StudentManage', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                Name: this.state.Name,
                age: this.state.age,
                PhoneNumber: this.state.PhoneNumber,
                Addres: this.state.Addres
            })
        })
            .then(res => res.json())
            .then((result) => {
                alert(result);
                this.refreshList();
            }, (error) => {
                alert('Failed');
            })
    }
    // crud operation
    changeName = (e) => {
        this.setState({ Name: e.target.value });
    }
    changeage = (e) => {
        this.setState({ age: e.target.value });
    }
    changePhoneNumber = (e) => {
        this.setState({ PhoneNumber: e.target.value });
    }
    changeAddres = (e) => {
        this.setState({ Addres: e.target.value });
    }


    render() {
        const {
            Students,
 
                id,
                
        } = this.state;


        return (
            <Container className="App">
                <h4 className="PageHeading">Enter Student Informations</h4>
                <Form className="form">
                    <Col>
                        <FormGroup row>
                            <Label for="name" sm={2}>Name</Label>
                            <Col sm={10}>
                                <Input type="text" name="Name" onChange={this.changeName} value={this.state.Name} placeholder="Enter Name" />
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label for="age" sm={2}>Age</Label>
                            <Col sm={10}>
                                <Input type="number" name="age"  onChange={this.changeage} value={this.state.age} placeholder="Enter age" />
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label for="PhoneNumber" sm={2}>Phone Number</Label>
                            <Col sm={10}>
                                <Input type="number" name="PhoneNumber" onChange={this.changePhoneNumber} value={this.state.Class} placeholder="Enter PhoneNumber" />
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label for="Addres" sm={2}>Address</Label>
                            <Col sm={10}>
                                <Input type="text" name="Addres"  onChange={this.changeAddres} value={this.state.Addres} placeholder="Enter Address" />
                            </Col>
                        </FormGroup>
                    </Col>
                    <Col>
                        <FormGroup row>
                            {id == 0 ?
                                <button type="button"
                                    className="btn btn-primary float-start"
                                    onClick={() => this.createClick()}
                                >Create</button>
                                : null}
                       </FormGroup>
                    </Col>
                </Form>
            </Container>
        );
    }

}

  