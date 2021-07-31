import React, { Component } from 'react';
import Laundry from './Laundry/Laundry';

export class Home extends Component {
  static displayName = Home.name;

  data = [
    {
      BlockName: "Block 1",
      IsActive: true,
      UserName: "John"
    },
    {
      BlockName: "Block 2",
      IsActive: false,
      UserName: null
    },
    {
      BlockName: "Block 3",
      IsActive: true,
      UserName: "Peter"
    },
  ]

  render () {
    return (
      <div>
        <Laundry data={this.data}/>
      </div>
    );
  }
}
