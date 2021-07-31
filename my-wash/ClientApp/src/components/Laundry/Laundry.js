import { event } from "jquery";
import React from "react";
import "./Laundry.css";

const Laundry = (props) => {
  let data = props.data;

  const onClickHandlerOff = (data) =>{
    console.log("Off event: ", data);
  }

  const onClickHandlerOn = (data) =>{
    console.log("On event: ", data);
  }

  return (
    <div className="wrappper">
      {data != null && data.length > 0
        ? data.map((block, index) => (
            <div className="block" key={index}>
              <p className="block-title">{block.BlockName}</p>
              {block.UserName != null ? (
                <p>User: {block.UserName}</p>
              ) : (
                <p>User: None</p>
              )}
              <p className={block.IsActive ? "active" : "free"}>
                Status: {block.IsActive ? "In use" : "Free"}
              </p>
              {block.IsActive ? (
                <button onClick={() => onClickHandlerOff(block)}>Switch-off</button>
              ) : (
                <button onClick={() => onClickHandlerOn(block)}>Switch-on</button>
              )}
            </div>
          ))
        : "No items."}
    </div>
  );
};

export default Laundry;
