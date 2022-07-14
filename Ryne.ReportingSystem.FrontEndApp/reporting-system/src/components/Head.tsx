import { FC } from "react";

interface Props {
  properties: {
    key: number | symbol | string,
    title: string,
  }[];
}

const Head: FC<Props> = ({ properties, }) => {
  return (
    <thead>
      <tr>
        <th>#</th>
        {
          properties.map(property => (
            <th key={String(property.key)}>{property.title}</th>
          ))
        }
      </tr>
    </thead>
  );
};

export default Head