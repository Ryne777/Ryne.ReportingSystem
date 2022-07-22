
interface Props {
  properties: {
    key: number | symbol | string,
    title: string,
  }[];
}

const Head = ({ properties, }: Props) => {
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