import React, { Component } from 'react';


export class Student extends Component {

    constructor(props) {
        super(props);

        this.state = {

            Students: []
        }
    }
    //get method
    refreshList() {

        fetch('https://localhost:7033/api/studentmanage')
            .then(response => response.json())
            .then(data => {
                this.setState({ Students: data });
            });
    }

    componentDidMount() {
        this.refreshList();
    }   

    render() {
        const {
            Students,          
        } = this.state;

        return (
            <div>
                <h3>This is Student page</h3>

                <table className="table table-striped">
                    <thead>
                        <tr>
                            <th>
                                Id
                            </th>
                            <th>
                                Name
                            </th>
                            <th>
                                Age
                            </th>
                            <th>
                                PhoneNumber
                            </th>
                            <th>
                                Address
                            </th>
                            <th>
                                Options
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        {Students.map(stu =>
                            <tr key={stu.id}>
                                <td>{stu.id}</td>
                                <td>{stu.Name}</td>
                                <td>{stu.age}</td>
                                <td>{stu.PhoneNumber}</td>
                                <td>{stu.Addres}</td>
                                <td>                                
                                </td>
                            </tr>
                        )}
                    </tbody>
                </table>              
                                                           
            </div>
        )
    }
}

